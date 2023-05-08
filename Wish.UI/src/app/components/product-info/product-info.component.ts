import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BehaviorSubject, Subscription, finalize, first, tap } from 'rxjs';
import { ProductService } from 'src/app/services/product.service';


@Component({
  selector: 'app-product-info',
  templateUrl: './product-info.component.html',
  styleUrls: ['./product-info.component.css']
})
export class ProductInfoComponent implements OnInit {
  ngOnInit(): void {
    this.getItem()
  }
  id: any;
  categoryId: any;
  productId: any;
  private routeSubscription: Subscription;
  item: any;

  constructor(private route: ActivatedRoute, private productService:ProductService){

    this.routeSubscription = route.params.subscribe(params=>{this.id=params['id'], this.getItem()
    });
  }
  readonly isLoading$ = new BehaviorSubject(true);

  getItem(){
    this.productService.getItemInfo(this.id).pipe(
      first(),
      tap((response) => this.item = response.data),
      finalize(() => this.isLoading$.next(false)),
    ).subscribe();
  }
}

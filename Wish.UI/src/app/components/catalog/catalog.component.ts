import { Component, OnInit } from '@angular/core';
import { ProductResponse } from 'src/app/models/Product/ProductResponse';
import { ProductService } from 'src/app/services/product.service';
import { ActivatedRoute} from '@angular/router';
import { Observable, Subscription, finalize, first, tap } from 'rxjs';
import { BehaviorSubject } from 'rxjs';

@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html',
  styleUrls: ['./catalog.component.css']
})
export class CatalogComponent implements OnInit {

  id: any;
  pageNumber: any;
  pageSize: any;
  items: any;
  private routeSubscription: Subscription;
  private querySubscription: Subscription;
  title: any;

  ngOnInit(){
    this.getPageTitle();
    this.getItems();
  }
  constructor(private route: ActivatedRoute, private productService:ProductService){

      this.routeSubscription = route.params.subscribe(params=>{this.id=params['id'], this.getItems()
    });
      this.querySubscription = route.queryParams.subscribe(
          (queryParam: any) => {
              this.pageNumber = queryParam['pageNumber'];
              this.pageSize = queryParam['pageSize'];
          },
      );
  }

  readonly isLoading$ = new BehaviorSubject(true);

  getItems(): void {
    this.productService.getAllProducts(this.id, this.pageNumber, this.pageSize)
    .pipe(
        first(),
        tap((response) => this.items = response.data),
        finalize(() => this.isLoading$.next(false)),
      ).subscribe();
  }
  getPageTitle()
  {
    var titleId = this.id;
    if(titleId === 1)
    {
      this.title = 'Кольца'
    }
    if(titleId === 2)
    {
      this.title = 'Серьги'
    }
    if(titleId === 3)
    {
      this.title = 'Ожерелья'
    }
    if(titleId === 4)
    {
      this.title = 'Браслеты'
    }
  }
  addToCartshop(productId:number) {
    this.productService.addToCartshop(productId).subscribe();
  }
}

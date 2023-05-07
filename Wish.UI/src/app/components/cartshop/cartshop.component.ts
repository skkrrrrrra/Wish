import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BehaviorSubject, Subscription, finalize, first, tap } from 'rxjs';
import { CartshopResponse } from 'src/app/models/Cartshop/CartshopResponse'
import { CartshopService } from 'src/app/services/cartshop.service';

@Component({
  selector: 'app-cartshop',
  templateUrl: './cartshop.component.html',
  styleUrls: ['./cartshop.component.css']
})
export class CartshopComponent implements OnInit{
  [x: string]: any;
  cartshopResponse = new CartshopResponse();

  ngOnInit(){
    this.getCartshopProducts();
  }

  pageNumber: any;
  pageSize: any;
  items: any;
  private routeSubscription: Subscription;
  private querySubscription: Subscription;
  title = 'Корзина';
  readonly isLoading$ = new BehaviorSubject(true);

  constructor(private route: ActivatedRoute, private cartshopService: CartshopService){

      this.routeSubscription = route.params.subscribe(params=>{this.getCartshopProducts();
    });
      this.querySubscription = route.queryParams.subscribe(
          (queryParam: any) => {
              this.pageNumber = queryParam['pageNumber'];
              this.pageSize = queryParam['pageSize'];
          },
      );
  }
  getCartshopProducts(){
    this.cartshopService.getCartshopItems(this.pageNumber, this.pageSize)
    .pipe(
        first(),
        tap((response) => this.items = response.data),
        finalize(() => this.isLoading$.next(false)),
      ).subscribe();
  }

  async deleteItem(productId: number) {
    await this.cartshopService.deleteFromCartshop(productId).subscribe({
      complete: () => this.getCartshopProducts(),
    });
  }

}

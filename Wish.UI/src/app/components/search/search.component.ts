import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BehaviorSubject, Subscription, finalize, first, tap } from 'rxjs';
import { ProductService } from 'src/app/services/product.service';
import { SearchService } from 'src/app/services/search.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit{

  items:any;
  searchString = ''
  private routeSubscription: Subscription;

  constructor(private route: ActivatedRoute, private searchService:SearchService, private productService:ProductService)
  {
      this.routeSubscription = route.params.subscribe(params=>{this.searchString=params['searchString'], this.GetItemsBySearchString(this.searchString)});
  }

  ngOnInit(): void {
    this.GetItemsBySearchString(this.searchString);
  }
  readonly isLoading$ = new BehaviorSubject(true);

  GetItemsBySearchString(searchString:string) {
    this.searchService.SearchProducts(searchString)
    .pipe(
      first(),
      tap((response) => this.items = response.data),
      finalize(() => this.isLoading$.next(false)),
    ).subscribe();
  }
  addToCartshop(productId:number) {
    this.productService.addToCartshop(productId).subscribe();
  }
}

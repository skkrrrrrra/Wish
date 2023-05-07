import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { CatalogComponent } from './components/catalog/catalog.component';
import { ProductInfoComponent } from './components/product-info/product-info.component';
import { RouterModule, Routes } from '@angular/router';
import { CartshopComponent } from './components/cartshop/cartshop.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http'
import { FormsModule } from '@angular/forms';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { AuthIntercaptor } from './services/auth.interceptor';


const appRoutes: Routes = [
  {path: '', component:HomeComponent},
  {path: 'login', component:LoginComponent},
  {path: 'register', component:RegisterComponent},
  {path: 'catalog/:id', component:CatalogComponent},
  {path: 'cartshop', component:CartshopComponent},
  {path: '**', component:NotFoundComponent},
]


@NgModule({
  declarations: [
    HomeComponent,
    AppComponent,
    LoginComponent,
    RegisterComponent,
    CatalogComponent,
    ProductInfoComponent,
    CartshopComponent,
    NotFoundComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: AuthIntercaptor,
    multi: true,
  }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

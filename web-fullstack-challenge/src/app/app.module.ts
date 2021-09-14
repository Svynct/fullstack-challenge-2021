import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BsModalService, ModalModule } from 'ngx-bootstrap/modal';
import { NgxPaginationModule } from 'ngx-pagination';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AppInterceptor } from './app.interceptor.service';
import { HomeComponent } from './pages/home/home.component';
import { EditarProdutoComponent } from './pages/produtos/editar-produto/editar-produto.component';
import { NovoProdutoComponent } from './pages/produtos/novo-produto/novo-produto.component';
import { ProdutosComponent } from './pages/produtos/produtos.component';
import { LogsModalComponent } from './pages/servicos/logs-modal/logs-modal.component';
import { ServicosComponent } from './pages/servicos/servicos.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ServicosComponent,
    ProdutosComponent,
    EditarProdutoComponent,
    NovoProdutoComponent,
    LogsModalComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    BrowserAnimationsModule,
    ModalModule,
    NgbModule,
    NgxPaginationModule
  ],
  providers: [BsModalService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AppInterceptor,
      multi: true
    }],
  bootstrap: [AppComponent]
})
export class AppModule { }

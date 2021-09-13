import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsModalService, ModalModule } from 'ngx-bootstrap/modal';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
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
    ModalModule
  ],
  providers: [BsModalService],
  bootstrap: [AppComponent]
})
export class AppModule { }

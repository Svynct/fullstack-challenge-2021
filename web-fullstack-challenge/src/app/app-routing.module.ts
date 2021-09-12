import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { ProdutosComponent } from './pages/produtos/produtos.component';
import { ServicosComponent } from './pages/servicos/servicos.component';
import { SobreComponent } from './pages/sobre/sobre.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'servicos', component: ServicosComponent },
  { path: 'produtos', component: ProdutosComponent },
  { path: 'sobre', component: SobreComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

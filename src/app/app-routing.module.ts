import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { AppComponent } from './app.component';
import { AuthGuard } from './guard/auth.guard';

const routes: Routes = [
  { path: 'Home', component: HomeComponent, canActivate: [AuthGuard] },
  { path: 'Login', component: AppComponent },
  { path: '*', redirectTo: ''}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

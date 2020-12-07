import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './auth.guard';
import { AccountProfileComponent } from './components/account-profile/account-profile.component';
import { CreateTourComponent } from './components/create-tour/create-tour.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { TourDetailsComponent } from './components/tour-details/tour-details.component';
import { ToursComponent } from './components/tours/tours.component';


const routes: Routes = [
  { path: '', component: ToursComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent},
  { path: 'profile', component: AccountProfileComponent},
  { path: 'tour', component: TourDetailsComponent},
  { path: 'create', component: CreateTourComponent, canActivate: [AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

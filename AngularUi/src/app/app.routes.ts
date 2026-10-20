import { Routes } from '@angular/router';
import { AddComponent } from './add/add.component';
import { DivideComponent } from './divide/divide.component';

export const routes: Routes = [
  { path: 'add', component: AddComponent },
  { path: 'divide', component: DivideComponent },
  { path: '', redirectTo: 'add', pathMatch: 'full' }
];

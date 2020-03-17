import { Component } from '@angular/core';
import {Router} from '@angular/router';
import {FormControl, FormGroup} from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  constructor(private router: Router) {
  }

  navigateToRequestPage(){
    this.router.navigate(['/request-leave']);
  }

}

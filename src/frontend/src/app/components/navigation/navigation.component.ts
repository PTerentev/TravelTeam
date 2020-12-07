import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent implements OnInit {
  loggedIn: boolean;
  constructor(private accountService: AccountService,
              private router: Router) { }

  ngOnInit(): void {
    this.loggedIn = this.accountService.loggedIn();
  }

  logout() {
    console.log("logout!");
    this.accountService.logout();
    location.reload();
  }

  accountShow() {
    this.router.navigate(['/profile'], { queryParams: { id:localStorage.getItem('userId') }})
    .then(() => {
      location.reload();
    });
  }
}

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Result } from 'src/app/models/Result';
import { UserDto } from 'src/app/models/UserDto';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-account-profile',
  templateUrl: './account-profile.component.html',
  styleUrls: ['./account-profile.component.css']
})
export class AccountProfileComponent implements OnInit {
  loggedIn: boolean;
  user: UserDto = new UserDto();
  constructor(private accountService: AccountService,
              private router: Router,
              private route: ActivatedRoute) { }

  ngOnInit(): void {
    const accountId = this.route.snapshot.queryParamMap.get('id');

    if (!!!accountId){
      this.router.navigate(['/']);
    }

    this.loggedIn = this.checkLogin(accountId);

    this.accountService.getInfo(accountId).subscribe(
      user => {
        this.user = user;
      },
      error => {
        this.router.navigate(['/']);
      }
    )
  }

  checkLogin(accountId: string): boolean {
    return accountId === localStorage.getItem('userId');
  }
}

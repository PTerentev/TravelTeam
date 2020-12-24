import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TourDto } from 'src/app/models/Tour/TourDto';
import { UserDto } from 'src/app/models/UserDto';
import { AccountService } from 'src/app/services/account.service';
import { TourService } from 'src/app/services/tour.service';

@Component({
  selector: 'app-account-profile',
  templateUrl: './account-profile.component.html',
  styleUrls: ['./account-profile.component.css']
})
export class AccountProfileComponent implements OnInit {
  tours: TourDto[];
  loggedIn: boolean;
  user: UserDto = new UserDto();
  constructor(private accountService: AccountService,
              private tourService: TourService,
              private router: Router,
              private route: ActivatedRoute) { }

  ngOnInit(): void {
    const accountId = this.route.snapshot.queryParamMap.get('id');

    if (!!!accountId){
      this.router.navigate(['/']);
    }

    this.loggedIn = this.checkLogin(accountId);

    if(this.loggedIn)
    {
      this.getTours();
    }

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
    return accountId === localStorage.getItem('userId') && this.accountService.loggedIn();
  }

  getTours() {
    this.tourService.getTourByUser().subscribe(
      result => {
        this.tours = result;
      }
    )
  }
}

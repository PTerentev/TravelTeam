import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TourDto } from 'src/app/models/Tour/TourDto';
import { UserDto } from 'src/app/models/UserDto';
import { TourService } from 'src/app/services/tour.service';

@Component({
  selector: 'app-tour-details',
  templateUrl: './tour-details.component.html',
  styleUrls: ['./tour-details.component.css']
})
export class TourDetailsComponent implements OnInit {
  tour: TourDto;
  tourParticipants: UserDto[];
  isTourOwner: boolean = false;

  constructor(private tourService: TourService,
    private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    const tourId = this.route.snapshot.queryParamMap.get('id');

    if (!!!tourId){
      this.router.navigate(['/']);
    }

    this.tourService.getTourById(tourId).subscribe(
      result => {
        this.tour = result;
        this.tourParticipants = this.tour.tourParticipants;
      },
      error => {
        this.router.navigate(['/']);
      }
    )
  }

  handleParticipate() {
    this.tourService.participate(this.tour.id).subscribe(
      success => {
        location.reload();
      }
    )
  }

}

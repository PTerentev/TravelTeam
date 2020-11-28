import { Component, OnInit } from '@angular/core';
import { TourService } from '../../services/tour.service'
import { TourShortDto } from '../../models/Tour/TourShortDto'
import { GetToursQuery } from '../../models/Tour/GetToursQuery'

@Component({
  selector: 'app-tours',
  templateUrl: './tours.component.html',
  styleUrls: ['./tours.component.css']
})
export class ToursComponent implements OnInit {
  tours: TourShortDto[];
  constructor(private tourService: TourService) { }

  ngOnInit(): void {

    let query:GetToursQuery = {
      page: 1,
      pageSize: 100
    }

    this.tourService.getTours(query).subscribe(
      value => this.tours = value.items
    );
  }

}

import { DatePipe } from '@angular/common';
import { Component, OnInit, Input } from '@angular/core';
import { TourDto } from '../../models/Tour/TourDto'

@Component({
  selector: 'app-single-tour',
  templateUrl: './single-tour.component.html',
  styleUrls: ['./single-tour.component.css']
})
export class SingleTourComponent implements OnInit {
  @Input() tour: TourDto;
  formattedDate:string;
  
  constructor() { }

  ngOnInit(): void {
    const pipe = new DatePipe('ru-RU');
    this.formattedDate = pipe.transform(this.tour.date, 'fullDate');
  }

}

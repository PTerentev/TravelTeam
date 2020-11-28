import { Component, OnInit, Input } from '@angular/core';
import { TourShortDto } from '../../models/Tour/TourShortDto'

@Component({
  selector: 'app-single-tour',
  templateUrl: './single-tour.component.html',
  styleUrls: ['./single-tour.component.css']
})
export class SingleTourComponent implements OnInit {
  @Input() tour: TourShortDto;
  
  constructor() { }

  ngOnInit(): void {
  }

}

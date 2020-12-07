import { Component, OnInit } from '@angular/core';
import { CreateTourCommand } from 'src/app/models/Tour/CreateTourCommand';
import { AccountService } from 'src/app/services/account.service';
import { TourService } from 'src/app/services/tour.service';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-tour',
  templateUrl: './create-tour.component.html',
  styleUrls: ['./create-tour.component.css']
})
export class CreateTourComponent implements OnInit {
  command: CreateTourCommand;
  errors: string[];
  constructor(private tourService: TourService,
              private router: Router) { }

  ngOnInit(): void {
    this.command = new CreateTourCommand();
  }

  submit(form: NgForm){
    this.tourService.createTour(this.command).subscribe(
      result => {
        if (!!result.id) {
          this.router.navigate(['/tour'], { queryParams: { id:result.id }});
        }
      },
      error => {
        console.log(error);
        this.errors = ['Ошибка регистрации!'];
        this.errors = this.errors.concat(this.parseBadResponse(error));
      }
    )
  }

  parseBadResponse(response: any): string[] {
    return response.error.Extensions.errors[0].Messages;
  }

}

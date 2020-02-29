import { Component, OnInit } from '@angular/core';
import { JudgeService } from '../judge.service';

@Component({
  selector: 'app-start-page',
  templateUrl: './start-page.component.html',
  styleUrls: ['./start-page.component.scss']
})
export class StartPageComponent implements OnInit {

  constructor(private judgeapi: JudgeService) { }

  ngOnInit() {
    this.queryItems();
  }

  result: any;
  isLoading: boolean;
  errorMessage: any;
  queryItems() {

    this.isLoading = true;
    this.errorMessage = null;
    this.judgeapi.fetchTeams().subscribe({
      next: response => {
        this.result = response;
        this.isLoading = false;
      },
      error: error => {
        this.isLoading = false;
        this.errorMessage = error;
      }
    });
  }
}

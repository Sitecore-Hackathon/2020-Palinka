import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { JudgeService } from '../judge.service';

@Component({
  selector: 'app-teamdetailpage',
  templateUrl: './teamdetailpage.component.html',
  styleUrls: ['./teamdetailpage.component.scss']
})
export class TeamdetailpageComponent implements OnInit {

  constructor(private route: ActivatedRoute,
    private judgeapi: JudgeService,
    private router: Router) { }

  ngOnInit() {
    let itemId = this.route.snapshot.queryParamMap.get('itemid');
    this.fetchTeam(itemId);
  }
  
  teamData: any;
  errorMessage: any;
  isLoading: boolean;

  fetchTeam(id: any) {
    this.judgeapi.fetchTeamById(id).subscribe({
      next: response => {
        this.teamData = response;
        this.isLoading = false;
        console.log(this.teamData);
      },
      error: error => {
        this.isLoading = false;
        this.errorMessage = error;
      }
    });
  }

  comments: any;
  points: any;

  sendData() {

    this.judgeapi.sendPoint({ "Comment": this.comments, "Point": this.points, "TeamId": this.teamData.ID }).subscribe({
      next: response => {

        this.isLoading = false;
        this.router.navigate(['/']);
      },
      error: error => {
        this.isLoading = false;
        this.errorMessage = error;
      }
    });
  }
}

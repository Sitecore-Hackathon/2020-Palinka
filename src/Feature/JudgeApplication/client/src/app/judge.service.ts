import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class JudgeService {

  constructor(private httpClient:HttpClient) { }
   baseUrl = "/sitecore/api/judge/";

   fetchTeams(){
     return this.httpClient.get(this.baseUrl+"teams");
   }

   fetchTeamById(id:any){
    return this.httpClient.get(this.baseUrl+"detail?id="+id);
  }

  sendPoint(body:any){
    return this.httpClient.post(this.baseUrl+"sendpoint", body);
  }
}

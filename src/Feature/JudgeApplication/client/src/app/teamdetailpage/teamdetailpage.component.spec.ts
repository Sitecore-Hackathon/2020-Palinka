import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TeamdetailpageComponent } from './teamdetailpage.component';

describe('TeamdetailpageComponent', () => {
  let component: TeamdetailpageComponent;
  let fixture: ComponentFixture<TeamdetailpageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TeamdetailpageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TeamdetailpageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});

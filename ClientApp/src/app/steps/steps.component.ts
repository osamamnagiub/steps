import {Component, Inject, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ActivatedRoute} from "@angular/router";
import {StepsService} from "../steps.service";

@Component({
  selector: 'app-steps',
  templateUrl: './steps.component.html',
  styleUrls: ['./steps.component.css']
})
export class StepsComponent implements OnInit {
  stepId: any;
  constructor(private http: HttpClient, private route: ActivatedRoute,
              @Inject('BASE_URL') private baseUrl: string, public stepsService: StepsService) {
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.stepId = params['id'];
    });

    this.stepsService.getAllSteps();
  }

  addStep() {
    this.stepsService.addStep();
  }

  removeStep(stepId: string) {
    this.stepsService.removeStep(stepId);
  }
}

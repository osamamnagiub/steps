import {Component, Inject, OnInit} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {HttpClient} from "@angular/common/http";
import {StepsService} from "../steps.service";
import {map} from "rxjs/operators";
import {Observable} from "rxjs";

@Component({
  selector: 'app-step',
  templateUrl: './step.component.html',
  styleUrls: ['./step.component.css']
})
export class StepComponent implements OnInit {
  stepItems: Observable<any>;
  selectedItem: any;
  private stepId: any;


  constructor(private route: ActivatedRoute,
              private http: HttpClient,
              @Inject('BASE_URL') private baseUrl: string,
              private stepsService: StepsService) {
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.stepId = params['id'];
      this.stepItems = this.stepsService.steps.pipe(
        map(steps => {
          let step = steps.find(item => item.id == this.stepId)
          if (step)
            return step.items;
        })
      );

    });
  }

  saveNewItem($event: any) {
    this.selectedItem = undefined;
    this.stepsService.saveItem($event, this.stepId);
  }

  addNewItem() {
    this.selectedItem = {title: '', description: ''};
  }

  deleteItem(id) {
    this.stepsService.deleteItem(this.stepId, id);
  }

}

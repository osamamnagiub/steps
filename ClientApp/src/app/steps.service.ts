import {Inject, Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {BehaviorSubject, Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class StepsService {
  private _steps = new BehaviorSubject<any[]>([]);
  private dataStore: { steps: any[] } = {steps: []};

  get steps() {
    return this._steps.asObservable();
  }

  constructor(private http: HttpClient,
              @Inject('BASE_URL') private baseUrl: string) {
  }

  getAllSteps() {
    this.http.get<any[]>(`${this.baseUrl}steps`).subscribe(
      data => {
        this.dataStore.steps = data;
        this._steps.next(Object.assign({}, this.dataStore).steps);
      },
      error => console.log('Could not load steps.')
    );
    ;
  }

  addStep() {
    this.http.post<any[]>(`${this.baseUrl}steps`, null)
      .subscribe(
        data => {
          this.dataStore.steps.push(data);
          this._steps.next(Object.assign({}, this.dataStore).steps);
        },
        error => console.log('Could not create step.')
      );
  }

  removeStep(stepId: string) {
    this.http.delete<any[]>(`${this.baseUrl}steps/${stepId}`, {observe: "response"}).subscribe(
      response => {
        this.dataStore.steps.forEach((t, i) => {
          if (t.id === stepId) {
            this.dataStore.steps.splice(i, 1);
          }
        });

        this._steps.next(Object.assign({}, this.dataStore).steps);
      },
      error => console.log('Could not delete step.')
    );
    ;
  }


  saveItem($event: any, stepId: any) {
    if ($event.id) {
      // update
      this.http.put<any[]>(`${this.baseUrl}items/${$event.id}`, $event)
        .subscribe(
          (data: any) => {

            // getting all steps for simplicity
            // in a real case we will manipulate the steps array to save round trips
            this.getAllSteps();

            this._steps.next(Object.assign({}, this.dataStore).steps);
          },
          error => console.log('Could not create item.')
        );
    } else {
      // create
      this.http.post<any[]>(`${this.baseUrl}steps/${stepId}/items`, $event)
        .subscribe(
          (data: any) => {
            // getting all steps for simplicity
            // in a real case we will manipulate the steps array to save round trips
            this.getAllSteps();

            this._steps.next(Object.assign({}, this.dataStore).steps);
          },
          error => console.log('Could not create item.')
        );
    }
  }

  getItems(stepId: any) {
    this.http.get<any[]>(`${this.baseUrl}items/${stepId}`).subscribe(
      (data: any) => {

        // getting all steps for simplicity
        // in a real case we will manipulate the steps array to save round trips
        this.getAllSteps();

        this._steps.next(Object.assign({}, this.dataStore).steps);
      },
      error => console.log('Could not create item.')
    );
    ;
  }

  deleteItem(stepId: any, id) {
    this.http.delete<any[]>(`${this.baseUrl}items/${stepId}/${id}`)
      .subscribe(
        (data: any) => {

          // getting all steps for simplicity
          // in a real case we will manipulate the steps array to save round trips
          this.getAllSteps();

          this._steps.next(Object.assign({}, this.dataStore).steps);
        },
        error => console.log('Could not create item.')
      );
  }
}

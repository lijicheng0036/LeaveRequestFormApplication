import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, filter, catchError } from 'rxjs/operators';
import { Leave } from '../models/leave.model';
import { Observable } from 'rxjs';

@Injectable()
export class LeaveRequestService {

  constructor(private http: HttpClient) {
  }

  getEmployees() {
    return this.http.get('/api/employees');
  }

  getLeaveTypes() {
    return this.http.get('/api/leave-types');
  }

  getDepartments() {
    return this.http.get('/api/departments');
  }

  createNewLeave(newLeave: Leave): Observable<Leave> {
    return this.http.post<Leave>('/api/createNewLeave', newLeave);
  }
}

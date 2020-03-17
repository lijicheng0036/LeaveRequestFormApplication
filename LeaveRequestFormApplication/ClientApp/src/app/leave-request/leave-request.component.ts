import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { LeaveRequestService } from '../services/leave-request.service';
import { Employee } from '../models/employee.model';
import { Department } from '../models/department.model';
import { LeaveType } from '../models/leaveType.model';
import { Leave } from '../models/leave.model';

@Component({
  selector: 'app-leave-request',
  templateUrl: './leave-request.component.html',
  styleUrls: ['./leave-request.component.css']
})
export class LeaveRequestComponent implements OnInit {

  employees: Employee[];
  departments: Department[];
  leaveTypes: LeaveType[];

  selectedDepartmentId: number;
  leaveSubject: string;
  leaveDescription: string;
  selectedLeaveType: number;
  selectedEmployeeId: number;
  availableEmployee: any[];

  dateRange = { start: null, end: null };

  constructor(private service: LeaveRequestService) {
  }

  ngOnInit() {
    this.service.getEmployees()
      .subscribe(result => {
        this.employees = result as Employee[];
      }, (error) => {
        console.error(error);
      });

    this.service.getLeaveTypes()
      .subscribe(result => {
        this.leaveTypes = result as LeaveType[];
      }, (error) => {
        console.error(error);
      });

    this.service.getDepartments()
      .subscribe(result => {
        this.departments = result as Department[];
      }, (error) => {
        console.error(error);
      });
  }

  onDepartmentChange() {
    this.availableEmployee = [];
    this.availableEmployee = this.employees.filter(e => Number(e.departmentId) === Number(this.selectedDepartmentId));
  }

  onSubmit() {
    let newLeave: Leave = {
      id: -1,
      title: this.leaveSubject,
      leaveTypeId: this.selectedLeaveType,
      startDate: this.dateRange.start,
      endDate: this.dateRange.end,
      lastUpdated: null,
      isApproved: false,
      description: this.leaveDescription,
      duration: 0,
      employeeId: this.selectedEmployeeId
    };

    this.service.createNewLeave(newLeave);
  }
}

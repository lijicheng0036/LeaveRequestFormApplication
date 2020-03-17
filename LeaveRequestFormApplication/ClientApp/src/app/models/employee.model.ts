import {Leave} from './leave.model';

export interface Employee {
  id: string,
  firstName: string,
  lastName: string,
  gender: string,
  email: string,
  departmentId: number,
  leaves: Leave[]
}

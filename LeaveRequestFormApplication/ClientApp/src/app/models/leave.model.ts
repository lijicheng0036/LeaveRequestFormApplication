export interface Leave {
  id: number,
  title: string,
  leaveTypeId: number,
  startDate: Date,
  endDate: Date,
  lastUpdated: Date,
  duration: number,
  description: string,
  isApproved: boolean,
  employeeId: number
}

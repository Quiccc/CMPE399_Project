export interface AllTasks {
  taskId: bigint;
  taskName: string;
  deadline: string;
  statusId: bigint;
  statusName: string;
  assignedUsers: AssignedTo[];
}

export interface AssignedTo {
userId: bigint;
userFirstName: string;
userLastName: string;
}

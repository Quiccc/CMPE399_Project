export interface AllTasks {
  taskId: bigint;
  taskName: string;
  deadline: string;
  assignedUsers: AssignedTo[];
}

export interface AssignedTo {
userId: bigint;
userFirstName: string;
userLastName: string;
}

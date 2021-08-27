import { Component } from "@angular/core";
import { MenuItem } from "primeng/api";

@Component({
  selector: "app-menubar",
  templateUrl: "./menubar.component.html",
})
export class MenubarComponent {
  items: MenuItem[];

  ngOnInit() {
    if (localStorage.getItem("role") == "Admin"){
      this.items = [
        { label: "Home", icon: "pi pi-fw pi-home", routerLink: "/" },
        {
          label: "Manage Users",
          icon: "pi pi-fw pi-user",
          items: [
            { label: "Add User", icon: "pi pi-fw pi-user-plus" },
            { label: "Remove User", icon: "pi pi-fw pi-trash" },
          ],
        },
        {
          label: "Manage Tasks",
          icon: "pi pi-fw pi-pencil",
          items: [
            { label: "Add Task", icon: "pi pi-fw pi-plus" },
            { label: "Remove Task", icon: "pi pi-fw pi-trash" },
            { label: "My Tasks", icon: "pi pi-fw pi-list" },
          ],
        },
      ];
    }
    else if (localStorage.getItem("role") == "User"){
      this.items = [
        { label: "Home", icon: "pi pi-fw pi-home", routerLink: "/" },
        {
          label: "Manage Tasks",
          icon: "pi pi-fw pi-pencil",
          items: [
            { label: "My Tasks", icon: "pi pi-fw pi-list" }
          ]
        },
      ];
    }
    else {
      this.items = [ { label: "Home", icon: "pi pi-fw pi-home", routerLink: "/" } ]
    }
    this.isLoggedIn();
  }
  isLoggedIn(): boolean {
     if(localStorage.getItem("jwt") && this.items.length == 1){
      this.ngOnInit();
      return true;
    }
    else if (localStorage.getItem("jwt")) return true;
    else return false;
  }
  logOut() {
    localStorage.clear();
    this.isLoggedIn();
    this.ngOnInit();
  }
}

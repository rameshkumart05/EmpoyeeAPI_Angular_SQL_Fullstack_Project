import { Routes } from '@angular/router';
import { LoginComponent } from './Pages/login/login.component';
import { HeaderComponent } from './Pages/header/header.component';
import { DashboardComponent } from './Pages/dashboard/dashboard.component';
import { EmployeeFormComponent } from './Pages/employee-form/employee-form.component';
import { DepartmentComponent } from './Pages/department/department.component';
import { DesignationComponent } from './Pages/designation/designation.component';
import { EmployeelistComponent } from './Pages/employeelist/employeelist.component';
export const routes: Routes = [
    {
        path: '',
        redirectTo: 'login',
        pathMatch: 'full'
    },
    {
        path: 'login',
        component: LoginComponent
    },
    {
        path: '',
        component: HeaderComponent,
        children: [
            {
                path: 'dashboard',
                component: DashboardComponent
            },
            {
                path: 'new-employee',
                component: EmployeeFormComponent
            },
            {
                path: 'employees',
                component: EmployeelistComponent
            },
            {
                path: 'department',
                component: DepartmentComponent
            },
            {
                path: 'designation',
                component: DesignationComponent
            }
        ]
    }
];

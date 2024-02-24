import { Routes } from "@angular/router";

export const routes: Routes = [
    
    {
        path: "",
        loadComponent:
            () => import("./Components/register/register.component")
                .then(c => c.RegisterComponent)
    },
    {
        path: "Login",
        loadComponent
            : () => import("./Components/login/login.component")
                .then(c => c.LoginComponent)
    },
    {
        path: "Register",
        loadComponent:
            () => import("./Components/register/register.component")
                .then(c => c.RegisterComponent)
    },
    {
        path: "Dispatch",
        loadComponent:
            () => import("./Components/DispatchComponents/dispatch-layout/dispatch-layout.component")
                .then(c => c.DispatchLayoutComponent),
        children:
            [
                {
                    path: "",
                    loadComponent:
                        () => import("./Components/DispatchComponents/User/index/index.component")
                            .then(c => c.IndexComponent),
                    children: [{
                        path: "",
                        loadComponent:
                            () => import("./Components/DispatchComponents/User/index/index.component")
                                .then(c => c.IndexComponent),
                    }]
                },
                {
                    path: "User",
                    children: [{
                        path: "",
                        loadComponent:
                            () => import("./Components/DispatchComponents/User/index/index.component")
                                .then(c => c.IndexComponent),
                    }, {
                        path: "Search",
                        loadComponent:
                            () => import("./Components/DispatchComponents/User/valid-user/valid-user.component")
                                .then(c => c.ValidUserComponent),
                    }
                        , {
                        path: "Edit",
                        loadComponent:
                            () => import("./Components/DispatchComponents/User/edit/edit.component")
                                .then(c => c.EditComponent),
                    }]
                },
                {
                    path: "Disaster",
                    children: [{
                        path: "",
                        loadComponent:
                            () => import("./Components/DispatchComponents/Disaster/index/index.component")
                                .then(c => c.IndexComponent),

                    }, {
                        path: "List",
                        loadComponent:
                            () => import("./Components/DispatchComponents/Disaster/list/list.component")
                                .then(c => c.ListComponent),
                    }]
                },
                {
                    path: "EmergencyReport",
                    children: [{
                        path: "",
                        loadComponent:
                            () => import("./Components/DispatchComponents/EmergencyReport/index/index.component")
                                .then(c => c.IndexComponent),

                    }, {
                        path: "List/:status",
                        loadComponent:
                            () => import("./Components/DispatchComponents/EmergencyReport/list/list.component")
                                .then(c => c.ListComponent),
                    }, {
                        path: "Details/:id",
                        loadComponent:
                            () => import("./Components/DispatchComponents/EmergencyReport/details/details.component")
                                .then(c => c.DetailsComponent),
                    }]
                },
                {
                    path: "Needer",
                    loadComponent: () => import("./Components/DispatchComponents/needer/needer.component")
                        .then(c => c.NeederComponent)
                },
                {
                    path: "Operation",
                    children: [
                        {
                            path: "MyOperations",
                            loadComponent: () => import("./Components/DispatchComponents/Operation/my-operations/my-operations.component")
                                .then(c => c.MyOperationsComponent)
                        },
                        {
                            path: "AssignedDetails/:id/:city",
                            loadComponent: () => import("./Components/DispatchComponents/Operation/assigned-details/assigned-details.component")
                                .then(c => c.AssignedDetailsComponent)
                        },
                        {
                            path: "Assign/:id",
                            loadComponent: () => import("./Components/DispatchComponents/Operation/assign/assign.component")
                                .then(c => c.AssignComponent)
                        },
                        {
                            path: "List/:status",
                            loadComponent: () => import("./Components/DispatchComponents/Operation/list/list.component")
                                .then(c => c.ListComponent)
                        },
                        {
                            path: "Details/:id",
                            loadComponent: () => import("./Components/DispatchComponents/Operation/details/details.component")
                                .then(c => c.DetailsComponent)
                        },
                        {
                            path: "AssignEmployee/:id/:city",
                            loadComponent: () => import("./Components/DispatchComponents/Operation/assign-employee/assign-employee.component")
                                .then(c => c.AssignEmployeeComponent)
                        },
                        {
                            path: "OperationDetails",
                            loadComponent: () => import("./Components/DispatchComponents/Operation/assigned-details/assigned-details.component")
                                .then(c => c.AssignedDetailsComponent)
                        }
                    ]
                }


            ]
    }

]
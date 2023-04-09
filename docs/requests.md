# Harvest Requests Map

This document provides the complete list of Harvest API endpoints and their corresponding request builders.

## Contents

- [Clients](#clients)
- [Client Contacts](#client-contacts)
- [Company](#company)
- [Estimates](#estimates)
  - [Estimate Messages](#estimate-messages)
- [Estimate Item Categories](#estimate-item-categories)
- [Expenses](#expenses)
- [Expense Categories](#expense-categories)
- [Invoices](#invoices)
  - [Invoice Messages](#invoice-messages)
  - [Invoice Payments](#invoice-payments)
- [Invoice Item Categories](#invoice-item-categories)
- [Projects](#projects)
  - [Project User Assignments](#project-user-assignments)
  - [Project Task Assignments](#project-task-assignments)
- [Expense Reports](#expense-reports)
- [Uninvoiced Reports](#uninvoiced-reports)
- [Time Reports](#time-reports)
- [Project Budget Reports](#project-budget-reports)
- [Roles](#roles)
- [Tasks](#tasks)
- [Task Assignments](#task-assignments)
- [Time Entries](#time-entries)
- [Users](#users)
  - [User Teammates](#user-teammates)
  - [User Billable Rates](#user-billable-rates)
  - [User Cost Rates](#user-cost-rates)
  - [User Project Assignments](#user-project-assignments)
- [User Assignments](#user-assignments)

## Clients

For more information on the `/clients` endpoint, see the [Harvest API Documentation](https://help.getharvest.com/api-v2/clients-api/clients/clients/).

| API | SDK | URL |
|:-|:-|:-|
| List all clients | `harvestServiceClient.Clients.GetAsync()` | GET api.harvestapp.com/v2/clients |
| Retrieve a client | `harvestServiceClient.Clients[clientId].GetAsync()` | GET api.harvestapp.com/v2/clients/{clientId} |
| Create a client | `harvestServiceClient.Clients.PostAsync(CreateClient)` | POST api.harvestapp.com/v2/clients |
| Update a client | `harvestServiceClient.Clients[clientId].PatchAsync(UpdateClient)` | PATCH api.harvestapp.com/v2/clients/{clientId} |
| Delete a client | `harvestServiceClient.Clients[clientId].DeleteAsync()` | DELETE api.harvestapp.com/v2/clients/{clientId} |

## Client Contacts

For more information on the `/contacts` endpoint, see the [Harvest API Documentation](https://help.getharvest.com/api-v2/clients-api/clients/contacts/).

| API | SDK | URL |
|:-|:-|:-|
| List all contacts | `harvestServiceClient.Contacts.GetAsync()` | GET api.harvestapp.com/v2/contacts |
| Retrieve a contact | `harvestServiceClient.Contacts[contactId].GetAsync()` | GET api.harvestapp.com/v2/contacts/{contactId} |
| Create a contact | `harvestServiceClient.Contacts.PostAsync(CreateContact)` | POST api.harvestapp.com/v2/contacts |
| Update a contact | `harvestServiceClient.Contacts[contactId].PatchAsync(UpdateContact)` | PATCH api.harvestapp.com/v2/contacts/{contactId} |
| Delete a contact | `harvestServiceClient.Contacts[contactId].DeleteAsync()` | DELETE api.harvestapp.com/v2/contacts/{contactId} |

## Company

For more information on the `/company` endpoint, see the [Harvest API Documentation](https://help.getharvest.com/api-v2/company-api/company/company/).

| API | SDK | URL |
|:-|:-|:-|
| Retrieve a company | `harvestServiceClient.Company.GetAsync()` | GET api.harvestapp.com/v2/company |
| Update a company | `harvestServiceClient.Company.PatchAsync(UpdateCompany)` | PATCH api.harvestapp.com/v2/company |

## Estimates

For more information on the `/estimates` endpoint, see the [Harvest API Documentation](https://help.getharvest.com/api-v2/estimates-api/estimates/estimates/).

| API | SDK | URL |
|:-|:-|:-|
| List all estimates | `harvestServiceClient.Estimates.GetAsync()` | GET api.harvestapp.com/v2/estimates |
| Retrieve an estimate | `harvestServiceClient.Estimates[estimateId].GetAsync()` | GET api.harvestapp.com/v2/estimates/{estimateId} |
| Create an estimate | `harvestServiceClient.Estimates.PostAsync(CreateEstimate)` | POST api.harvestapp.com/v2/estimates |
| Update an estimate | `harvestServiceClient.Estimates[estimateId].PatchAsync(UpdateEstimate)` | PATCH api.harvestapp.com/v2/estimates/{estimateId} |
| Delete an estimate | `harvestServiceClient.Estimates[estimateId].DeleteAsync()` | DELETE api.harvestapp.com/v2/estimates/{estimateId} |

### Estimate Messages

For more information on the `/estimates/{estimateId}/messages` endpoint, see the [Harvest API Documentation](https://help.getharvest.com/api-v2/estimates-api/estimates/estimate-messages/).

| API | SDK | URL |
|:-|:-|:-|
| List all messages for an estimate | `harvestServiceClient.Estimates[estimateId].Messages.GetAsync()` | GET api.harvestapp.com/v2/estimates/{estimateId}/messages |
| Create an estimate message | `harvestServiceClient.Estimates[estimateId].Messages.PostAsync(CreateEstimateMessage)` | POST api.harvestapp.com/v2/estimates/{estimateId}/messages |
| Delete an estimate message | `harvestServiceClient.Estimates[estimateId].Messages[messageId].DeleteAsync()` | DELETE api.harvestapp.com/v2/estimates/{estimateId}/messages/{messageId} |

> **Note:** When marking an estimate as a new state (e.g. sent, accepted, declined, etc.), use the **Create an estimate message** endpoint.

## Estimate Item Categories

For more information on the `/estimate_item_categories` endpoint, see the [Harvest API Documentation](https://help.getharvest.com/api-v2/estimates-api/estimates/estimate-item-categories/).

| API | SDK | URL |
|:-|:-|:-|
| List all estimate item categories | `harvestServiceClient.EstimateItemCategories.GetAsync()` | GET api.harvestapp.com/v2/estimate_item_categories |
| Retrieve an estimate item category | `harvestServiceClient.EstimateItemCategories[estimateItemCategoryId].GetAsync()` | GET api.harvestapp.com/v2/estimate_item_categories/{estimateItemCategoryId} |
| Create an estimate item category | `harvestServiceClient.EstimateItemCategories.PostAsync(CreateEstimateItemCategory)` | POST api.harvestapp.com/v2/estimate_item_categories |
| Update an estimate item category | `harvestServiceClient.EstimateItemCategories[estimateItemCategoryId].PatchAsync(UpdateEstimateItemCategory)` | PATCH api.harvestapp.com/v2/estimate_item_categories/{estimateItemCategoryId} |
| Delete an estimate item category | `harvestServiceClient.EstimateItemCategories[estimateItemCategoryId].DeleteAsync()` | DELETE api.harvestapp.com/v2/estimate_item_categories/{estimateItemCategoryId} |

## Expenses

For more information on the `/expenses` endpoint, see the [Harvest API Documentation](https://help.getharvest.com/api-v2/expenses-api/expenses/expenses/).

| API | SDK | URL |
|:-|:-|:-|
| List all expenses | `harvestServiceClient.Expenses.GetAsync()` | GET api.harvestapp.com/v2/expenses |
| Retrieve an expense | `harvestServiceClient.Expenses[expenseId].GetAsync()` | GET api.harvestapp.com/v2/expenses/{expenseId} |
| Create an expense | `harvestServiceClient.Expenses.PostAsync(CreateExpense)` | POST api.harvestapp.com/v2/expenses |
| Update an expense | `harvestServiceClient.Expenses[expenseId].PatchAsync(UpdateExpense)` | PATCH api.harvestapp.com/v2/expenses/{expenseId} |
| Delete an expense | `harvestServiceClient.Expenses[expenseId].DeleteAsync()` | DELETE api.harvestapp.com/v2/expenses/{expenseId} |

## Expense Categories

For more information on the `/expense_categories` endpoint, see the [Harvest API Documentation](https://help.getharvest.com/api-v2/expenses-api/expenses/expense-categories/).

| API | SDK | URL |
|:-|:-|:-|
| List all expense categories | `harvestServiceClient.ExpenseCategories.GetAsync()` | GET api.harvestapp.com/v2/expense_categories |
| Retrieve an expense category | `harvestServiceClient.ExpenseCategories[expenseCategoryId].GetAsync()` | GET api.harvestapp.com/v2/expense_categories/{expenseCategoryId} |
| Create an expense category | `harvestServiceClient.ExpenseCategories.PostAsync(CreateExpenseCategory)` | POST api.harvestapp.com/v2/expense_categories |
| Update an expense category | `harvestServiceClient.ExpenseCategories[expenseCategoryId].PatchAsync(UpdateExpenseCategory)` | PATCH api.harvestapp.com/v2/expense_categories/{expenseCategoryId} |
| Delete an expense category | `harvestServiceClient.ExpenseCategories[expenseCategoryId].DeleteAsync()` | DELETE api.harvestapp.com/v2/expense_categories/{expenseCategoryId} |

## Invoices

For more information on the `/invoices` endpoint, see the [Harvest API Documentation](https://help.getharvest.com/api-v2/invoices-api/invoices/invoices/).

| API | SDK | URL |
|:-|:-|:-|
| List all invoices | `harvestServiceClient.Invoices.GetAsync()` | GET api.harvestapp.com/v2/invoices |
| Retrieve an invoice | `harvestServiceClient.Invoices[invoiceId].GetAsync()` | GET api.harvestapp.com/v2/invoices/{invoiceId} |
| Create a free-form invoice | `harvestServiceClient.Invoices.PostAsync(CreateFreeFormInvoice)` | POST api.harvestapp.com/v2/invoices |
| Create an invoice based on tracked time and expenses | `harvestServiceClient.Invoices.PostAsync(CreateTrackedInvoice)` | POST api.harvestapp.com/v2/invoices |
| Update an invoice | `harvestServiceClient.Invoices[invoiceId].PatchAsync(UpdateInvoice)` | PATCH api.harvestapp.com/v2/invoices/{invoiceId} |
| Delete an invoice | `harvestServiceClient.Invoices[invoiceId].DeleteAsync()` | DELETE api.harvestapp.com/v2/invoices/{invoiceId} |

### Invoice Messages

For more information on the `/invoices/{invoiceId}/messages` endpoint, see the [Harvest API Documentation](https://help.getharvest.com/api-v2/invoices-api/invoices/invoice-messages/).

| API | SDK | URL |
|:-|:-|:-|
| List all messages for an invoice | `harvestServiceClient.Invoices[invoiceId].Messages.GetAsync()` | GET api.harvestapp.com/v2/invoices/{invoiceId}/messages |
| Create an invoice message | `harvestServiceClient.Invoices[invoiceId].Messages.PostAsync(CreateInvoiceMessage)` | POST api.harvestapp.com/v2/invoices/{invoiceId}/messages |
| Delete an invoice message | `harvestServiceClient.Invoices[invoiceId].Messages[messageId].DeleteAsync()` | DELETE api.harvestapp.com/v2/invoices/{invoiceId}/messages/{messageId} |

> **Note:** When marking an invoice as a new state (e.g. sent, paid, etc.), use the **Create an invoice message** endpoint.

### Invoice Payments

For more information on the `/invoices/{invoiceId}/payments` endpoint, see the [Harvest API Documentation](https://help.getharvest.com/api-v2/invoices-api/invoices/invoice-payments/).

| API | SDK | URL |
|:-|:-|:-|
| List all payments for an invoice | `harvestServiceClient.Invoices[invoiceId].Payments.GetAsync()` | GET api.harvestapp.com/v2/invoices/{invoiceId}/payments |
| Create an invoice payment | `harvestServiceClient.Invoices[invoiceId].Payments.PostAsync(CreateInvoicePayment)` | POST api.harvestapp.com/v2/invoices/{invoiceId}/payments |
| Delete an invoice payment | `harvestServiceClient.Invoices[invoiceId].Payments[paymentId].DeleteAsync()` | DELETE api.harvestapp.com/v2/invoices/{invoiceId}/payments/{paymentId} |

## Invoice Item Categories

For more information on the `/invoice_item_categories` endpoint, see the [Harvest API Documentation](https://help.getharvest.com/api-v2/invoices-api/invoices/invoice-item-categories/).

| API | SDK | URL |
|:-|:-|:-|
| List all invoice item categories | `harvestServiceClient.InvoiceItemCategories.GetAsync()` | GET api.harvestapp.com/v2/invoice_item_categories |
| Retrieve an invoice item category | `harvestServiceClient.InvoiceItemCategories[invoiceItemCategoryId].GetAsync()` | GET api.harvestapp.com/v2/invoice_item_categories/{invoiceItemCategoryId} |
| Create an invoice item category | `harvestServiceClient.InvoiceItemCategories.PostAsync(CreateInvoiceItemCategory)` | POST api.harvestapp.com/v2/invoice_item_categories |
| Update an invoice item category | `harvestServiceClient.InvoiceItemCategories[invoiceItemCategoryId].PatchAsync(UpdateInvoiceItemCategory)` | PATCH api.harvestapp.com/v2/invoice_item_categories/{invoiceItemCategoryId} |
| Delete an invoice item category | `harvestServiceClient.InvoiceItemCategories[invoiceItemCategoryId].DeleteAsync()` | DELETE api.harvestapp.com/v2/invoice_item_categories/{invoiceItemCategoryId} |

## Projects

For more information on the `/projects` endpoint, see the [Harvest API Documentation](https://help.getharvest.com/api-v2/projects-api/projects/projects/).

| API | SDK | URL |
|:-|:-|:-|
| List all projects | `harvestServiceClient.Projects.GetAsync()` | GET api.harvestapp.com/v2/projects |
| Retrieve a project | `harvestServiceClient.Projects[projectId].GetAsync()` | GET api.harvestapp.com/v2/projects/{projectId} |
| Create a project | `harvestServiceClient.Projects.PostAsync(CreateProject)` | POST api.harvestapp.com/v2/projects |
| Update a project | `harvestServiceClient.Projects[projectId].PatchAsync(UpdateProject)` | PATCH api.harvestapp.com/v2/projects/{projectId} |
| Delete a project | `harvestServiceClient.Projects[projectId].DeleteAsync()` | DELETE api.harvestapp.com/v2/projects/{projectId} |

### Project User Assignments

For more information on the `/projects/{projectId}/user_assignments` endpoint, see the [Harvest API Documentation](https://help.getharvest.com/api-v2/projects-api/projects/user-assignments/).

| API | SDK | URL |
|:-|:-|:-|
| List all user assignments for a specific project | `harvestServiceClient.Projects[projectId].UserAssignments.GetAsync()` | GET api.harvestapp.com/v2/projects/{projectId}/user_assignments |
| Retrieve a user assignment | `harvestServiceClient.Projects[projectId].UserAssignments[userAssignmentId].GetAsync()` | GET api.harvestapp.com/v2/projects/{projectId}/user_assignments/{userAssignmentId} |
| Create a user assignment | `harvestServiceClient.Projects[projectId].UserAssignments.PostAsync(CreateUserAssignment)` | POST api.harvestapp.com/v2/projects/{projectId}/user_assignments |
| Update a user assignment | `harvestServiceClient.Projects[projectId].UserAssignments[userAssignmentId].PatchAsync(UpdateUserAssignment)` | PATCH api.harvestapp.com/v2/projects/{projectId}/user_assignments/{userAssignmentId} |
| Delete a user assignment | `harvestServiceClient.Projects[projectId].UserAssignments[userAssignmentId].DeleteAsync()` | DELETE api.harvestapp.com/v2/projects/{projectId}/user_assignments/{userAssignmentId} |

### Project Task Assignments

For more information on the `/projects/{projectId}/task_assignments` endpoint, see the [Harvest API Documentation](https://help.getharvest.com/api-v2/projects-api/projects/task-assignments/).

| API | SDK | URL |
|:-|:-|:-|
| List all task assignments for a specific project | `harvestServiceClient.Projects[projectId].TaskAssignments.GetAsync()` | GET api.harvestapp.com/v2/projects/{projectId}/task_assignments |
| Retrieve a task assignment | `harvestServiceClient.Projects[projectId].TaskAssignments[taskAssignmentId].GetAsync()` | GET api.harvestapp.com/v2/projects/{projectId}/task_assignments/{taskAssignmentId} |
| Create a task assignment | `harvestServiceClient.Projects[projectId].TaskAssignments.PostAsync(CreateTaskAssignment)` | POST api.harvestapp.com/v2/projects/{projectId}/task_assignments |
| Update a task assignment | `harvestServiceClient.Projects[projectId].TaskAssignments[taskAssignmentId].PatchAsync(UpdateTaskAssignment)` | PATCH api.harvestapp.com/v2/projects/{projectId}/task_assignments/{taskAssignmentId} |
| Delete a task assignment | `harvestServiceClient.Projects[projectId].TaskAssignments[taskAssignmentId].DeleteAsync()` | DELETE api.harvestapp.com/v2/projects/{projectId}/task_assignments/{taskAssignmentId} |

## Expense Reports

For more information on the `/reports/expenses` endpoint, see the [Harvest API Documentation](https://help.getharvest.com/api-v2/reports-api/reports/expense-reports/).

| API | SDK | URL |
|:-|:-|:-|
| Clients Report | `harvestServiceClient.Reports.Expenses.Clients.GetAsync()` | GET api.harvestapp.com/v2/reports/expenses/clients |
| Projects Report | `harvestServiceClient.Reports.Expenses.Projects.GetAsync()` | GET api.harvestapp.com/v2/reports/expenses/projects |
| Expense Categories Report | `harvestServiceClient.Reports.Expenses.Categories.GetAsync()` | GET api.harvestapp.com/v2/reports/expenses/categories |
| Team Report | `harvestServiceClient.Reports.Expenses.Team.GetAsync()` | GET api.harvestapp.com/v2/reports/expenses/team |

## Uninvoiced Reports

For more information on the `/reports/uninvoiced` endpoint, see the [Harvest API Documentation](https://help.getharvest.com/api-v2/reports-api/reports/uninvoiced-report/).

| API | SDK | URL |
|:-|:-|:-|
| Uninvoiced Report | `harvestServiceClient.Reports.Uninvoiced.GetAsync()` | GET api.harvestapp.com/v2/reports/uninvoiced |

## Time Reports

For more information on the `/reports/time` endpoint, see the [Harvest API Documentation](https://help.getharvest.com/api-v2/reports-api/reports/time-reports/).

| API | SDK | URL |
|:-|:-|:-|
| Clients Report | `harvestServiceClient.Reports.Time.Clients.GetAsync()` | GET api.harvestapp.com/v2/reports/time/clients |
| Projects Report | `harvestServiceClient.Reports.Time.Projects.GetAsync()` | GET api.harvestapp.com/v2/reports/time/projects |
| Tasks Report | `harvestServiceClient.Reports.Time.Tasks.GetAsync()` | GET api.harvestapp.com/v2/reports/time/tasks |
| Team Report | `harvestServiceClient.Reports.Time.Team.GetAsync()` | GET api.harvestapp.com/v2/reports/time/team |

## Project Budget Reports

For more information on the `/reports/project_budget` endpoint, see the [Harvest API Documentation](https://help.getharvest.com/api-v2/reports-api/reports/project-budget-report/).

| API | SDK | URL |
|:-|:-|:-|
| Project Budget Report | `harvestServiceClient.Reports.ProjectBudget.GetAsync()` | GET api.harvestapp.com/v2/reports/project_budget |

## Roles

For more information on the `/roles` endpoint, see the [Harvest API Documentation](https://help.getharvest.com/api-v2/roles-api/roles/roles/).

| API | SDK | URL |
|:-|:-|:-|
| List all roles | `harvestServiceClient.Roles.GetAsync()` | GET api.harvestapp.com/v2/roles |
| Retrieve a role | `harvestServiceClient.Roles[roleId].GetAsync()` | GET api.harvestapp.com/v2/roles/{roleId} |
| Create a role | `harvestServiceClient.Roles.PostAsync(CreateRole)` | POST api.harvestapp.com/v2/roles |
| Update a role | `harvestServiceClient.Roles[roleId].PatchAsync(UpdateRole)` | PATCH api.harvestapp.com/v2/roles/{roleId} |
| Delete a role | `harvestServiceClient.Roles[roleId].DeleteAsync()` | DELETE api.harvestapp.com/v2/roles/{roleId} |

## Tasks

For more information on the `/tasks` endpoint, see the [Harvest API Documentation](https://help.getharvest.com/api-v2/tasks-api/tasks/tasks/).

| API | SDK | URL |
|:-|:-|:-|
| List all tasks | `harvestServiceClient.Tasks.GetAsync()` | GET api.harvestapp.com/v2/tasks |
| Retrieve a task | `harvestServiceClient.Tasks[taskId].GetAsync()` | GET api.harvestapp.com/v2/tasks/{taskId} |
| Create a task | `harvestServiceClient.Tasks.PostAsync(CreateTask)` | POST api.harvestapp.com/v2/tasks |
| Update a task | `harvestServiceClient.Tasks[taskId].PatchAsync(UpdateTask)` | PATCH api.harvestapp.com/v2/tasks/{taskId} |
| Delete a task | `harvestServiceClient.Tasks[taskId].DeleteAsync()` | DELETE api.harvestapp.com/v2/tasks/{taskId} |

## Task Assignments

For more information on the `/task_assignments` endpoint, see the [Harvest API Documentation](https://help.getharvest.com/api-v2/projects-api/projects/task-assignments/#list-all-task-assignments).

| API | SDK | URL |
|:-|:-|:-|
| List all task assignments | `harvestServiceClient.TaskAssignments.GetAsync()` | GET api.harvestapp.com/v2/task_assignments |

## Time Entries

For more information on the `/time_entries` endpoint, see the [Harvest API Documentation](https://help.getharvest.com/api-v2/timesheets-api/timesheets/time-entries/).

| API | SDK | URL |
|:-|:-|:-|
| List all time entries | `harvestServiceClient.TimeEntries.GetAsync()` | GET api.harvestapp.com/v2/time_entries |
| Retrieve a time entry | `harvestServiceClient.TimeEntries[timeEntryId].GetAsync()` | GET api.harvestapp.com/v2/time_entries/{timeEntryId} |
| Create a time entry via duration | `harvestServiceClient.TimeEntries.PostAsync(CreateTimeEntryByDuration)` | POST api.harvestapp.com/v2/time_entries |
| Create a time entry via start and end time | `harvestServiceClient.TimeEntries.PostAsync(CreateTimeEntryByStartEndTime)` | POST api.harvestapp.com/v2/time_entries |
| Update a time entry | `harvestServiceClient.TimeEntries[timeEntryId].PatchAsync(UpdateTimeEntry)` | PATCH api.harvestapp.com/v2/time_entries/{timeEntryId} |
| Delete a time entry | `harvestServiceClient.TimeEntries[timeEntryId].DeleteAsync()` | DELETE api.harvestapp.com/v2/time_entries/{timeEntryId} |
| Restart a stopped time entry | `harvestServiceClient.TimeEntries[timeEntryId].RestartAsync()` | POST api.harvestapp.com/v2/time_entries/{timeEntryId}/restart |
| Stop a running time entry | `harvestServiceClient.TimeEntries[timeEntryId].StopAsync()` | POST api.harvestapp.com/v2/time_entries/{timeEntryId}/stop |

## Users

For more information on the `/users` endpoint, see the [Harvest API Documentation](https://help.getharvest.com/api-v2/users-api/users/users/).

| API | SDK | URL |
|:-|:-|:-|
| List all users | `harvestServiceClient.Users.GetAsync()` | GET api.harvestapp.com/v2/users |
| Retrieve the currently authenticated user | `harvestServiceClient.Users.Me.GetAsync()` | GET api.harvestapp.com/v2/users/me |
| Retrieve a user | `harvestServiceClient.Users[userId].GetAsync()` | GET api.harvestapp.com/v2/users/{userId} |
| Create a user | `harvestServiceClient.Users.PostAsync(CreateUser)` | POST api.harvestapp.com/v2/users |
| Update a user | `harvestServiceClient.Users[userId].PatchAsync(User)` | PATCH api.harvestapp.com/v2/users/{userId} |
| Delete a user | `harvestServiceClient.Users[userId].DeleteAsync()` | DELETE api.harvestapp.com/v2/users/{userId} |

### User Teammates

For more information on the `/users/{userId}/teammates` endpoint, see the [Harvest API Documentation](https://help.getharvest.com/api-v2/users-api/users/teammates/).

| API | SDK | URL |
|:-|:-|:-|
| List all teammates for a specific user | `harvestServiceClient.Users[userId].Teammates.GetAsync()` | GET api.harvestapp.com/v2/users/{userId}/teammates |
| Update a user's assigned teammates | `harvestServiceClient.Users[userId].Teammates.PatchAsync(UserTeammates)` | PATCH api.harvestapp.com/v2/users/{userId}/teammates |

### User Billable Rates

For more information on the `/users/{userId}/billable_rates` endpoint, see the [Harvest API Documentation](https://help.getharvest.com/api-v2/users-api/users/billable-rates/).

| API | SDK | URL |
|:-|:-|:-|
| List all billable rates for a specific user | `harvestServiceClient.Users[userId].BillableRates.GetAsync()` | GET api.harvestapp.com/v2/users/{userId}/billable_rates |
| Retrieve a billable rate | `harvestServiceClient.Users[userId].BillableRates[billableRateId].GetAsync()` | GET api.harvestapp.com/v2/users/{userId}/billable_rates/{billableRateId} |
| Create a billable rate | `harvestServiceClient.Users[userId].BillableRates.PostAsync(CreateBillableRate)` | POST api.harvestapp.com/v2/users/{userId}/billable_rates |

### User Cost Rates

For more information on the `/users/{userId}/cost_rates` endpoint, see the [Harvest API Documentation](https://help.getharvest.com/api-v2/users-api/users/cost-rates/).

| API | SDK | URL |
|:-|:-|:-|
| List all cost rates for a specific user | `harvestServiceClient.Users[userId].CostRates.GetAsync()` | GET api.harvestapp.com/v2/users/{userId}/cost_rates |
| Retrieve a cost rate | `harvestServiceClient.Users[userId].CostRates[costRateId].GetAsync()` | GET api.harvestapp.com/v2/users/{userId}/cost_rates/{costRateId} |
| Create a cost rate | `harvestServiceClient.Users[userId].CostRates.PostAsync(CreateCostRate)` | POST api.harvestapp.com/v2/users/{userId}/cost_rates |

### User Project Assignments

For more information on the `/users/{userId}/project_assignments` endpoint, see the [Harvest API Documentation](https://help.getharvest.com/api-v2/users-api/users/project-assignments/).

| API | SDK | URL |
|:-|:-|:-|
| List active project assignments | `harvestServiceClient.Users[userId].ProjectAssignments.GetAsync()` | GET api.harvestapp.com/v2/users/{userId}/project_assignments |
| List active project assignments for the currently authenticated user | `harvestServiceClient.Users.Me.ProjectAssignments.GetAsync()` | GET api.harvestapp.com/v2/users/me/project_assignments |

## User Assignments

For more information on the `/user_assignments` endpoint, see the [Harvest API Documentation](https://help.getharvest.com/api-v2/projects-api/projects/user-assignments/#list-all-user-assignments).

| API | SDK | URL |
|:-|:-|:-|
| List all user assignments | `harvestServiceClient.UserAssignments.GetAsync()` | GET api.harvestapp.com/v2/user_assignments |

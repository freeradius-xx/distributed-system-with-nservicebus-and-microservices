# Distributed System

Example of a big company selling some kind of products. The workflow is complex and there is a need for departments (Crm, Shop itself, Sales, Shipping) to be separated and that's is why they have own websites.

Further more, every one of them (department) wants to be notified if there are changes in the workflow that have to be handled by a particular department (they don't want to send mails about the order's state so we have to find a way to notify them as soon as possible).

Crm => will have the responsibility to put a new products "in the shop" and take care about the price.
(code in distributed-system-part1 repository)

Workflow:

An order (Shop Website => distributed-system-part2) has been placed by a customer, the Sales Department (Sales Website => distributed-system-part3) should be notified about the new order (and to make some checks about it). After the Sales Department accepts (or denies => denying the order is not handled here) the order, it should let the Dispatching Department (Shipping Website => distributed-system-part4) know about it, so it can dispatch the order to the customer's address. And the customer should be notified about the current state of the order too => because she wants to know if and when she gets the product(s) she ordered :-) ...

The focus in this app was on showing how a distributed application works - low coupling between services through event based architecture, message durability, service bus role in a distributed app and usage of NServiceBus.
Therefore I didn't take care about MVVM (in Crm.Client.Wpf) nor using of some kind of IoC, or unit testing the code. Just for simplicity of this example => sagas have been taken out of this presentation (but there is an example of using sagas with NServiceBus in another repository => nservicebus-sagas.

---------------------------------------------------

These are the soultions that you`re going to start to see full power of the event nessaging:

Website (Shop)
Website (Sales department)
Website (Shipping department)
Desktop App (CRM)

They are playing together through MSMQ. Events are being published through Microservices, based on Pub/Sub pattern.

To see complete workflow in action you'll need to open every solution and mark some projects as startable:

1) CRM
  - Crm.Client.Wpf

2) SALES
  - Sales.Client.Mvc (website)
  - Sales.Service.Host (SignalR hosting app)
  - Sales.Handler.OrderProcessor (handles order being processed by the client => website)
  - Sales.Handler.OrderForwarder (handles forwarding orders to the dispatcher)
  - 
3) Shipping
  - Shipping.Client.Mvc (website)
  - Shipping.Service.Host (SignalR hosting app)
  - Shipping.Handler.OrderProcessor (handles order being processed by the sales department)
  - Shipping.Handler.ShippingProcessor ("dispatches" received orders)
  - 
4) WEBSITE
  - Website.Client.Mvc (website)
  - Website.Service.Host (SignalR hosting app)
  - Website.Handler.OrderProcessor (handles order being processed by the HomeController because web app sholud not be used to publish any kind of messages)
  - Website.Handler.AcceptOrder (handles status changes of the order's lifecycle => from Sales department)
  - Website.Handler.ShippingProcessor (handles status changes of the order's lifecycle => from Shipping department)
   
  
And now start solutions mentioned above, create a couple of products and let the workflow go by placing an order...

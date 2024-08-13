## Library App
This is a simple library system that can handle Borrowing of Books and CDs.
## Models

### 1. Inventory_Master
This model contains the details of the books, CD in the library. The fields in this model are:

- Id = Primary Key
- Item_Name = Name of the Book/CD
- Item_Type = Type of the Item (Book/CD)
- Status = Status of the Item (Available/Reserved)
- ISBN = ISBN of the Item
- Author = Author of the Item

### 2. User_Master
This model contains the details of the users who are registered in the library. The fields in this model are:
- Id = Primary Key
- User_Name = Name of the User
- Password = Password of the User
- Name = Name of the User
- Contact_No = Contact Number of the User
- Email = Email of the User
- Active = Status of the User (True / False)

### 3. Transaction_Master
This model contains the details of the transactions that are made in the library. The fields in this model are:
- Id = Primary Key
- Transaction_Type = Type of the Transaction (Borrow/Return)
- Reference_Date = Date of the Transaction
- Item_Id = Foreign Key from Inventory_Master
- User_Id = Foreign Key from User_Master

### 4. Reservation_Master
This model contains the details of the reservations that are made in the library. The fields in this model are:
- Id = Primary Key
- Reservation_Date = Date of the Reservation
- Item_Id = Foreign Key from Inventory_Master
- User_Id = Foreign Key from User_Master

## Guest_Message__Master
This model contains the details of the guests who are not registered in the library. The fields in this model are:
- Id = Primary Key
- Name = Name of the Guest
- Email = Email of the Guest
- Message = Message of the Guest
- Date = Date of the Message
- Replied_Date = Date of the Reply



## Reservation Process
Guest goes to search page. This page will have a search bar where the guest can search for the book or CD. The search will be based on the Item_Name and Author. The guest can see the details of the book or CD. If the book is not reserved already. The guest can click on the Reserve button to reserve the book or CD. The guest will be asked to enter the Name and Email. Once the guest enters the details, the book or CD will be reserved for the guest.  The status of the book or CD will be changed to Reserved.

In Admin's dashboard, the admin can see the list of reservations. The admin can click on the reservation to see the details of the reservation. The admin can also click on the Issue button to issue the book or CD to the guest. Once the book or CD is issued, a transaction will be created in the Transaction_Master table. When the book or CD is returned, the admin can click on the Return button to return the book or CD. The status of the book or CD will be changed to Available. A transaction will be created in the Transaction_Master table.


# TODO

- [  ] Add a return button for guest.
- [  ] Add email validation when returning.
- [  ] Message right after the reservation process.
- [  ] Add Item Name in transaction screen
- [  ] [ Issue, Return ]
- [  ] Show client's messages in the table for reservation and return.
- [  ] Message for guest in the send message screen.
- [  ] Alert for replying a message. In-Line Input field
- [  ] Bookwise grouping for transaction.
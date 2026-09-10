CREATE DATABASE LibraryManagementDB;
GO

USE LibraryManagementDB;
GO

CREATE TABLE Authors
(
    AuthorID INT IDENTITY(1,1) PRIMARY KEY,
    AuthorName VARCHAR(100) NOT NULL,
    Email VARCHAR(100),
    Phone VARCHAR(20)
);

CREATE TABLE Categories
(
    CategoryID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName VARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE Books
(
    BookID INT IDENTITY(1,1) PRIMARY KEY,
    Title VARCHAR(200) NOT NULL,
    ISBN VARCHAR(20) UNIQUE,
    AuthorID INT NOT NULL,
    CategoryID INT NOT NULL,
    Publisher VARCHAR(100),
    PublicationYear INT,
    Quantity INT NOT NULL,
    AvailableQuantity INT NOT NULL,

    CONSTRAINT FK_Books_Authors
        FOREIGN KEY (AuthorID)
        REFERENCES Authors(AuthorID),

    CONSTRAINT FK_Books_Categories
        FOREIGN KEY (CategoryID)
        REFERENCES Categories(CategoryID),

    CONSTRAINT CK_Books_Quantity
        CHECK (Quantity >= 0),

    CONSTRAINT CK_Books_AvailableQuantity
        CHECK (AvailableQuantity >= 0),

    CONSTRAINT CK_Books_AvailableLessThanQuantity
        CHECK (AvailableQuantity <= Quantity)
);

CREATE TABLE Members
(
    MemberID INT IDENTITY(1,1) PRIMARY KEY,
    FullName VARCHAR(100) NOT NULL,
    Email VARCHAR(100),
    Phone VARCHAR(20),
    Address VARCHAR(200),
    JoinDate DATE NOT NULL DEFAULT GETDATE()
);

CREATE TABLE BookIssues
(
    IssueID INT IDENTITY(1,1) PRIMARY KEY,
    BookID INT NOT NULL,
    MemberID INT NOT NULL,
    IssueDate DATE NOT NULL,
    DueDate DATE NOT NULL,

    CONSTRAINT FK_BookIssues_Books
        FOREIGN KEY (BookID)
        REFERENCES Books(BookID),

    CONSTRAINT FK_BookIssues_Members
        FOREIGN KEY (MemberID)
        REFERENCES Members(MemberID),

    CONSTRAINT CK_BookIssues_Dates
        CHECK (DueDate >= IssueDate)
);

CREATE TABLE Returns
(
    ReturnID INT IDENTITY(1,1) PRIMARY KEY,
    IssueID INT NOT NULL UNIQUE,
    ReturnDate DATE NOT NULL,

    CONSTRAINT FK_Returns_BookIssues
        FOREIGN KEY (IssueID)
        REFERENCES BookIssues(IssueID)
);

CREATE TABLE Fines
(
    FineID INT IDENTITY(1,1) PRIMARY KEY,
    ReturnID INT NOT NULL UNIQUE,
    FineAmount DECIMAL(10,2) NOT NULL DEFAULT 0,
    PaidStatus VARCHAR(20) NOT NULL DEFAULT 'Unpaid',

    CONSTRAINT FK_Fines_Returns
        FOREIGN KEY (ReturnID)
        REFERENCES Returns(ReturnID),

    CONSTRAINT CK_Fines_Amount
        CHECK (FineAmount >= 0),

    CONSTRAINT CK_Fines_Status
        CHECK (PaidStatus IN ('Paid', 'Unpaid'))
);
select * from LibraryManagementDB;


USE LibraryManagementDB;
GO

/* =========================
   AUTHORS
   ========================= */

INSERT INTO Authors (AuthorName, Email, Phone)
VALUES
('J.K. Rowling', 'jkrowling@example.com', '9800000001'),
('George Orwell', 'georgeorwell@example.com', '9800000002'),
('Dan Brown', 'danbrown@example.com', '9800000003'),
('Agatha Christie', 'agatha@example.com', '9800000004'),
('Paulo Coelho', 'paulo@example.com', '9800000005'),
('Stephen King', 'stephenking@example.com', '9800000006'),
('Jane Austen', 'janeausten@example.com', '9800000007'),
('Mark Twain', 'marktwain@example.com', '9800000008'),
('Leo Tolstoy', 'leotolstoy@example.com', '9800000009'),
('Ernest Hemingway', 'hemingway@example.com', '9800000010');
GO


/* =========================
   CATEGORIES
   ========================= */

INSERT INTO Categories (CategoryName)
VALUES
('Fiction'),
('Mystery'),
('Science Fiction'),
('Biography'),
('Self Help'),
('Romance'),
('History'),
('Fantasy'),
('Thriller'),
('Classic');
GO


/* =========================
   BOOKS
   ========================= */

INSERT INTO Books
(
    Title,
    ISBN,
    AuthorID,
    CategoryID,
    Publisher,
    PublicationYear,
    Quantity,
    AvailableQuantity
)
VALUES
('Harry Potter and the Philosopher''s Stone',
 '9780747532699',
 1,
 8,
 'Bloomsbury',
 1997,
 10,
 10),

('1984',
 '9780451524935',
 2,
 1,
 'Signet Classics',
 1949,
 8,
 8),

('The Da Vinci Code',
 '9780307474278',
 3,
 2,
 'Doubleday',
 2003,
 7,
 7),

('Murder on the Orient Express',
 '9780062693662',
 4,
 2,
 'HarperCollins',
 1934,
 6,
 6),

('The Alchemist',
 '9780062315007',
 5,
 5,
 'HarperOne',
 1988,
 10,
 10),

('The Shining',
 '9780307743657',
 6,
 9,
 'Doubleday',
 1977,
 5,
 5),

('Pride and Prejudice',
 '9780141439518',
 7,
 6,
 'Penguin Classics',
 1813,
 8,
 8),

('The Adventures of Tom Sawyer',
 '9780486400778',
 8,
 10,
 'Dover Publications',
 1876,
 6,
 6),

('War and Peace',
 '9780199232765',
 9,
 7,
 'Oxford University Press',
 1869,
 5,
 5),

('The Old Man and the Sea',
 '9780684830490',
 10,
 1,
 'Scribner',
 1952,
 7,
 7);
GO


/* =========================
   MEMBERS
   ========================= */

INSERT INTO Members
(
    FullName,
    Email,
    Phone,
    Address,
    JoinDate
)
VALUES
('Ramesh Tharu',
 'ramesh@example.com',
 '9810000001',
 'Kathmandu',
 '2026-01-10'),

('Gopal Thakur',
 'gopal@example.com',
 '9810000002',
 'Lalitpur',
 '2026-01-15'),

('Krishna Thapa',
 'krishna@example.com',
 '9810000003',
 'Bhaktapur',
 '2026-02-01'),

('Arpan Sharma',
 'arpan@example.com',
 '9810000004',
 'Kathmandu',
 '2026-02-05'),

('Ram Sharma',
 'ram@example.com',
 '9810000005',
 'Pokhara',
 '2026-02-10'),

('Sita Thapa',
 'sita@example.com',
 '9810000006',
 'Lalitpur',
 '2026-02-15'),

('Hari Karki',
 'hari@example.com',
 '9810000007',
 'Bhaktapur',
 '2026-02-20'),

('Nisha Gurung',
 'nisha@example.com',
 '9810000008',
 'Kathmandu',
 '2026-03-01'),

('Bikash Adhikari',
 'bikash@example.com',
 '9810000009',
 'Pokhara',
 '2026-03-05'),

('Rojina Shrestha',
 'rojina@example.com',
 '9810000010',
 'Kathmandu',
 '2026-03-10');
GO


/* =========================
   BOOK ISSUES
   ========================= */

INSERT INTO BookIssues
(
    BookID,
    MemberID,
    IssueDate,
    DueDate
)
VALUES
(1, 1, '2026-08-01', '2026-08-15'),
(2, 2, '2026-08-05', '2026-08-19'),
(3, 3, '2026-08-10', '2026-08-24'),
(4, 4, '2026-08-15', '2026-08-29'),
(5, 5, '2026-08-20', '2026-09-03');
GO


/* =========================
   RETURNS
   ========================= */

INSERT INTO Returns
(
    IssueID,
    ReturnDate
)
VALUES
(1, '2026-08-14'),
(2, '2026-08-25'),
(3, '2026-08-24'),
(4, '2026-09-05');
GO


/* =========================
   FINES
   ========================= */

INSERT INTO Fines
(
    ReturnID,
    FineAmount,
    PaidStatus
)
VALUES
(1, 0.00, 'Paid'),
(2, 60.00, 'Unpaid'),
(3, 0.00, 'Paid'),
(4, 70.00, 'Unpaid');
GO




SELECT
    b.BookID,
    b.Title,
    b.ISBN,
    a.AuthorName,
    c.CategoryName,
    b.Publisher,
    b.PublicationYear,
    b.Quantity,
    b.AvailableQuantity
FROM Books b
JOIN Authors a
    ON b.AuthorID = a.AuthorID
JOIN Categories c
    ON b.CategoryID = c.CategoryID;
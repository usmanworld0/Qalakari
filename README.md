# Qalakari - Photography Talent Platform

A photography talent website built with Blazor Server where photographers can showcase their talent, offer their services, list opportunities, and share photos with the community.

## 🌟 Features

### For Photographers
- **Portfolio Management**: Create and manage professional photography portfolios
- **Service Listings**: Add and manage photography gigs with pricing and availability
- **Photo Gallery**: Upload and showcase photography work
- **Calendar Integration**: Manage availability and bookings
- **Profile Management**: Edit and update photographer profiles

### For Clients
- **Browse Photographers**: Search and filter photographers by location, style, and budget
- **Browse Opportunities**: Find photography opportunities posted by clients
- **View Portfolios**: Browse photographer galleries and portfolios
- **Contact System**: Connect with photographers directly

### Platform Features
- **User Authentication**: Secure signup and login system
- **Responsive Design**: Mobile-friendly interface with modern UI
- **Search & Filters**: Advanced filtering for photographers and opportunities
- **Dashboard**: Personalized dashboard for managing content
- **Photo Sharing**: Community photo gallery with sharing capabilities

## 🛠️ Technology Stack

- **Framework**: ASP.NET Core Blazor Server (.NET 9.0)
- **Database**: SQL Server with Microsoft.Data.SqlClient
- **UI Framework**: Bootstrap 5
- **Styling**: Custom CSS with CSS Variables
- **Authentication**: Custom user management system
- **File Upload**: Built-in photo upload functionality

## 📦 Dependencies

```xml
<PackageReference Include="Microsoft.Data.SqlClient" Version="6.0.2" />
🚀 Getting Started
Prerequisites
.NET 9.0 SDK
SQL Server (LocalDB or full instance)
Visual Studio 2022 or VS Code
Installation
Clone the repository
git clone https://github.com/yourusername/qalakari.git
cd qalakari
Set up the database

Update the connection string in appsettings.json
{
  "ConnectionStrings": {
    "DefaultConnection": "Your_SQL_Server_Connection_String"
  }
}
Create database tables

-- Users table
CREATE TABLE Users (
    Id int IDENTITY(1,1) PRIMARY KEY,
    FirstName nvarchar(50) NOT NULL,
    LastName nvarchar(50) NOT NULL,
    Email nvarchar(100) NOT NULL UNIQUE,
    Password nvarchar(255) NOT NULL,
    Age int
);

-- Gigs table
CREATE TABLE Gigs (
    Id int IDENTITY(1,1) PRIMARY KEY,
    Title nvarchar(100) NOT NULL,
    Description nvarchar(500) NOT NULL,
    Price decimal(18,2) NOT NULL,
    ServiceType nvarchar(50) NOT NULL,
    City nvarchar(50) NOT NULL,
    ImageUrl nvarchar(500) NOT NULL,
    UserId int NOT NULL,
    PhoneNumber nvarchar(20) NOT NULL,
    Availability nvarchar(max),
    UserName nvarchar(100),
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);

-- Opportunities table
CREATE TABLE Opportunities (
    Id int IDENTITY(1,1) PRIMARY KEY,
    Title nvarchar(100) NOT NULL,
    Description nvarchar(500) NOT NULL,
    Budget decimal(18,2) NOT NULL,
    EventType nvarchar(50) NOT NULL,
    Location nvarchar(50) NOT NULL,
    ContactEmail nvarchar(100) NOT NULL,
    UserId int NOT NULL,
    EventDates nvarchar(max),
    UserName nvarchar(100),
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);

-- Photos table
CREATE TABLE Photos (
    Id int IDENTITY(1,1) PRIMARY KEY,
    UserId int NOT NULL,
    Title nvarchar(200) NOT NULL,
    Description nvarchar(1000),
    ImageUrl nvarchar(500) NOT NULL,
    UploadedAt datetime2 NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);
Restore dependencies
dotnet restore
Run the application
dotnet run
Access the application

Open your browser and navigate to https://localhost:5001 or http://localhost:5000
📱 Application Structure
Qalakar/
├── Components/
│   ├── Data/                  # Data models and services
│   │   ├── User.cs           # User model
│   │   ├── UserService.cs    # User data service
│   │   ├── Gig.cs           # Photography gig model
│   │   ├── GigService.cs    # Gig data service
│   │   ├── Opportunity.cs   # Opportunity model
│   │   ├── OpportunityService.cs
│   │   ├── Photo.cs         # Photo model
│   │   └── PhotoService.cs  # Photo data service
│   ├── Layout/              # Layout components
│   │   ├── MainLayout.razor
│   │   └── NavMenu.razor
│   ├── Pages/               # Page components
│   │   ├── Home.razor       # Landing page
│   │   ├── Dashboard.razor  # User dashboard
│   │   ├── Login.razor      # Authentication
│   │   ├── Signup.razor
│   │   ├── BrowsePhotographers.razor
│   │   ├── BrowseOpportunity.razor
│   │   ├── AddGigs.razor    # Add photography services
│   │   ├── AddOpportunities.razor
│   │   ├── AddPhotos.razor  # Photo upload
│   │   ├── ViewPhotos.razor # Photo gallery
│   │   ├── Contact.razor    # Contact forms
│   │   └── EditProfile.razor
│   ├── App.razor           # Root component
│   └── _Imports.razor      # Global imports
├── wwwroot/                # Static files
│   ├── css/               # Custom stylesheets
│   ├── lib/               # Third-party libraries
│   └── Uploads/           # Uploaded photos
├── Properties/
├── appsettings.json       # Configuration
└── Program.cs            # Application entry point
 Key Features Walkthrough
User Dashboard
Centralized hub for managing gigs, opportunities, and photos
Quick stats and recent activity overview
Easy navigation to all platform features
Photography Services (Gigs)
Add detailed service listings with pricing
Manage availability calendar
Include portfolio images and contact information
Opportunities
Browse photography job opportunities
Filter by event type, location, and budget
Easy application and contact system
Photo Gallery
Community-driven photo sharing
Advanced search and filtering
Photo upload with metadata
🔒 Security Features
Input validation and sanitization
SQL injection prevention with parameterized queries
File upload restrictions and validation
User authentication and session management
🤝 Contributing
Fork the repository
Create a feature branch (git checkout -b feature/AmazingFeature)
Commit your changes (git commit -m 'Add some AmazingFeature')
Push to the branch (git push origin feature/AmazingFeature)
Open a Pull Request
📄 License
This project is licensed under the MIT License - see the LICENSE.md file for details.

📞 Contact
Project Link: https://github.com/yourusername/qalakari

Contact Information:

Address: Room-03 Ground Floor Al-Sahib Heights E11/4, Islamabad
Phone: 0304-5313474
🔮 Future Enhancements
<input disabled="" type="checkbox"> Real-time messaging system
<input disabled="" type="checkbox"> Payment integration
<input disabled="" type="checkbox"> Advanced booking system
<input disabled="" type="checkbox"> Mobile app development
<input disabled="" type="checkbox"> Social media integration
<input disabled="" type="checkbox"> Review and rating system
<input disabled="" type="checkbox"> Advanced analytics dashboard
<input disabled="" type="checkbox"> Email notifications
<input disabled="" type="checkbox"> Multi-language support
🐛 Known Issues
Photo upload size limit currently set to 10MB
Calendar availability system needs timezone support
Search functionality could be enhanced with full-text search

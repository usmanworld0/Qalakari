```markdown
# Qalakari - Photography Talent Platform

A Blazor Server-based platform for photographers to showcase their portfolios, offer services, list opportunities, and engage with a community of clients and creators.

## 🌟 Features

### For Photographers
- **Portfolio Management**: Build and customize professional portfolios.
- **Service Listings**: Create and manage photography gigs with pricing and availability.
- **Photo Gallery**: Upload and display photography work.
- **Calendar Integration**: Schedule and track bookings.
- **Profile Management**: Update personal and professional details.

### For Clients
- **Browse Photographers**: Filter by location, style, or budget.
- **Explore Opportunities**: Discover photography gigs and projects.
- **View Portfolios**: Access photographers' galleries and portfolios.
- **Contact System**: Connect directly with photographers.

### Platform Features
- **User Authentication**: Secure signup and login.
- **Responsive Design**: Seamless experience across devices.
- **Search & Filters**: Easily find photographers or opportunities.
- **Dashboard**: Manage gigs, photos, and opportunities.
- **Photo Sharing**: Community-driven gallery with sharing options.

## 🛠️ Tech Stack
- **Framework**: ASP.NET Core Blazor Server (.NET 9.0)
- **Database**: SQL Server with Microsoft.Data.SqlClient
- **UI**: Bootstrap 5 with custom CSS
- **Authentication**: Custom user management
- **File Upload**: Secure photo upload system

## 🚀 Getting Started

### Prerequisites
- .NET 9.0 SDK
- SQL Server (LocalDB or full instance)
- Visual Studio 2022 or VS Code

### Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/qalakari.git
   cd qalakari
   ```
2. Update the connection string in `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Your_SQL_Server_Connection_String"
     }
   }
   ```
3. Set up the database using the provided SQL scripts (Users, Gigs, Opportunities, Photos).
4. Restore dependencies:
   ```bash
   dotnet restore
   ```
5. Run the application:
   ```bash
   dotnet run
   ```
6. Access at `https://localhost:5001` or `http://localhost:5000`.

## 📱 Application Structure
```
Qalakari/
├── Components/
│   ├── Data/                # Models and services (User, Gig, Opportunity, Photo)
│   ├── Layout/             # MainLayout, NavMenu
│   ├── Pages/              # Core pages (Home, Dashboard, Login, etc.)
│   ├── App.razor          # Root component
│   └── _Imports.razor     # Global imports
├── wwwroot/               # Static files (CSS, libraries, uploads)
├── Properties/
├── appsettings.json       # Configuration
└── Program.cs            # Entry point
```

## 🔒 Security
- Input validation and sanitization
- Parameterized queries to prevent SQL injection
- Secure file upload with restrictions
- Robust authentication and session management

## 🤝 Contributing
1. Fork the repository.
2. Create a feature branch (`git checkout -b feature/AmazingFeature`).
3. Commit changes (`git commit -m 'Add some AmazingFeature'`).
4. Push to the branch (`git push origin feature/AmazingFeature`).
5. Open a Pull Request.

## 📄 License
MIT License - see `LICENSE.md` for details.

## 📞 Contact
- **Project Link**: https://github.com/yourusername/qalakari
- **Address**: Room-03, Ground Floor, Al-Sahib Heights, E11/4, Islamabad
- **Phone**: 0304-5313474

## 🔮 Future Enhancements
- Real-time messaging
- Payment integration
- Advanced booking system
- Mobile app
- Social media integration
- Reviews and ratings
- Analytics dashboard
- Email notifications
- Multi-language support

## 🐛 Known Issues
- Photo upload limited to 10MB
- Calendar lacks timezone support
- Search could benefit from full-text indexing
```

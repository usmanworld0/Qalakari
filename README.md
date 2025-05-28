
# 📸 Qalakari - Photography Talent Platform 🌟

A vibrant, Blazor Server-powered platform where photographers showcase their creativity, offer services, explore opportunities, and connect with a passionate community.

## 🎨 Key Features

### 📷 For Photographers
- **Portfolio Creation** ✨: Build stunning, customizable portfolios.
- **Gig Listings** 💼: Offer photography services with clear pricing and availability.
- **Photo Gallery** 🖼️: Upload and share your best shots.
- **Booking Calendar** 📅: Manage schedules effortlessly.
- **Profile Customization** 👤: Keep your professional details up-to-date.

### 🔍 For Clients
- **Find Photographers** 🕵️: Search by location, style, or budget.
- **Discover Opportunities** 📢: Browse photography gigs and projects.
- **Explore Portfolios** 🗂️: View photographers' work in rich galleries.
- **Direct Contact** 📩: Connect with photographers seamlessly.

### 🌐 Platform Highlights
- **Secure Authentication** 🔐: Safe and simple signup/login.
- **Responsive Design** 📱: Beautiful, mobile-friendly interface.
- **Smart Search** 🔎: Filter photographers and opportunities with ease.
- **User Dashboard** 📊: Manage gigs, photos, and more in one place.
- **Community Gallery** 🤝: Share and explore photos with others.

## 🛠️ Tech Stack
- **Framework**: ASP.NET Core Blazor Server (.NET 9.0) 🚀
- **Database**: SQL Server with Microsoft.Data.SqlClient 🗄️
- **UI**: Bootstrap 5 with vibrant custom CSS 🎨
- **Authentication**: Secure custom user system 🔒
- **File Upload**: Robust photo upload functionality 📤

## 🚀 Get Started

### 🛠️ Prerequisites
- .NET 9.0 SDK
- SQL Server (LocalDB or full instance)
- Visual Studio 2022 or VS Code

### ⚙️ Installation
1. **Clone the Repository**:
   ```bash
   git clone https://github.com/yourusername/qalakari.git
   cd qalakari
   ```
2. **Configure the Database**:
   - Update `appsettings.json` with your SQL Server connection string:
     ```json
     {
       "ConnectionStrings": {
         "DefaultConnection": "Server=localhost;Database=Qalakari;Trusted_Connection=True;"
       }
     }
     ```
   - Run the provided SQL scripts to create tables (`Users`, `Gigs`, `Opportunities`, `Photos`).
3. **Restore Dependencies**:
   ```bash
   dotnet restore
   ```
4. **Launch the App**:
   ```bash
   dotnet run
   ```
5. **Access Qalakari**:
   - Open your browser at `https://localhost:5001` or `http://localhost:5000`.

## 📂 Project Structure
```
Qalakari/
├── Components/               # Core app components
│   ├── Data/                # Models & services (User, Gig, Opportunity, Photo)
│   ├── Layout/              # UI layouts (MainLayout, NavMenu)
│   ├── Pages/               # Pages (Home, Dashboard, Login, etc.)
│   ├── App.razor           # Root component
│   └── _Imports.razor      # Global imports
├── wwwroot/                 # Static assets
│   ├── css/                # Custom styles
│   ├── lib/                # Third-party libraries
│   └── Uploads/            # User-uploaded photos
├── Properties/              # Configuration files
├── appsettings.json         # App settings
└── Program.cs              # Entry point
```

## 🔐 Security Features
- **Input Validation** ✅: Prevents malicious inputs.
- **SQL Injection Protection** 🛡️: Uses parameterized queries.
- **File Upload Safety** 📂: Strict validation and size limits.
- **Authentication** 🔑: Secure user sessions.

## 🤝 How to Contribute
1. Fork the repository.
2. Create a feature branch: `git checkout -b feature/YourAmazingFeature`.
3. Commit changes: `git commit -m 'Add YourAmazingFeature'`.
4. Push to the branch: `git push origin feature/YourAmazingFeature`.
5. Submit a Pull Request.

## 📜 License
Licensed under the MIT License. See `LICENSE.md` for details.

## 📬 Contact Us
- **Project**: [github.com/yourusername/qalakari](https://github.com/yourusername/qalakari)
- **Address**: Room-03, Ground Floor, Al-Sahib Heights, E11/4, Islamabad
- **Phone**: 0304-5313474

## 🌈 Future Plans
- 💬 Real-time chat system
- 💸 Payment gateway integration
- 📅 Enhanced booking system
- 📱 Mobile app development
- 🌐 Social media sharing
- ⭐ Review and rating system
- 📈 Advanced analytics
- ✉️ Email notifications
- 🌍 Multi-language support

## 🐞 Known Issues
- Photo uploads capped at 10MB.
- Calendar needs timezone support.
- Search functionality could use full-text indexing.

---

🌟 **Join Qalakari and capture the moment!** 📸
```

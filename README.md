# Secure Message & File Encryptor with ForEncryption

A .NET 8 solution for secure encryption and decryption, featuring both a Windows Forms application for files and an ASP.NET Core web interface for messages.

## Projects

- **SecureFileEncryptor**: A Windows Forms application for encrypting and decrypting files with password protection.
- **ForEncryption**: An ASP.NET Core MVC web application for encrypting and decrypting messages via a web interface.

## Features

- Strong file encryption and decryption (Windows app)
- Secure message encryption and decryption (Web app)
- Password protection for sensitive files and messages
- User-friendly Windows Forms and web interfaces
- .NET 8 support

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Visual Studio 2022 or later

### Build and Run

#### SecureFileEncryptor (WinForms)

1. Open the solution in Visual Studio.
2. Set `SecureFileEncryptor` as the startup project.
3. Build and run the project.

#### ForEncryption (ASP.NET Core MVC)

1. Open the solution in Visual Studio.
2. Set `ForEncryption` as the startup project.
3. Build and run the project.
4. Navigate to `https://localhost:5001` (or the specified port).

## Usage

- Use the Windows Forms app to encrypt/decrypt files locally.
- Use the web app to encrypt/decrypt messages through your browser.

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License

This project is licensed under the MIT License.
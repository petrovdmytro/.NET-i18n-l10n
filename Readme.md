# Internationalization and localization logic in ASP.NET Core
This is localized ASP NET Core MVC application.
Three locales are defined:
-UA (default one)
-EN
-FR

It contains few localized numbers, dates and unit of measurements.

## How to run application
- cd ./i18n_l10n_MVC_NETCore/i18n_l10n_MVC_NETCore
- run "dotnet publish -p:PublishProfile=FolderProfile"
- cd ./bin/Debug/net6.0/publish
- run "dotnet i18n_l10n_MVC_NETCore.dll"
- open the browser and type https://localhost:5001/ in URL address input

## Example urls how to change locale
When the application is started it localized with default ukranian locale, that equals to https://localhost:5001/?culture=ua-UA
To switch to US or french locales there are following routes:
- https://localhost:5001/?culture=en-US
- https://localhost:5001/?culture=fr-FR
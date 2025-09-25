NoteWiki 📝
===========

A **note-taking web app** built with **ASP.NET Core MVC**, **SQL Server**, and **MongoDB**, featuring **Google Authentication**. Users can create and organize their notes inside "Note Boxes," with metadata stored in SQL and note contents stored in MongoDB for efficiency.

* * * * *

✨ Features
----------

-   🔐 **Google Login** with cookie authentication

-   📦 **Note Boxes** to organize notes by category

-   🗒 **Notes** with metadata (title, timestamps) in SQL Server and content in MongoDB

-   ✏️ **Create, Edit, and Delete** notes with real-time updates

-   📂 **Separate storage layers**:

    -   **SQL Server** → Users, NoteBoxes, Note Metadata

    -   **MongoDB** → Note Content

* * * * *

🛠 Tech Stack
-------------

-   **Backend**: ASP.NET Core MVC (C#)

-   **Frontend**: Razor Views + Bootstrap

-   **Authentication**: Google OAuth 2.0 + Cookie Authentication

-   **Database**:

    -   SQL Server → Entity Framework Core

    -   MongoDB → MongoDB.Driver

* * * * *

📸 Screenshots
-------------------------

<img width="1897" height="947" alt="Landing" src="https://github.com/user-attachments/assets/7a992113-e502-4d8d-bc18-a6cd3464c98d" />
<img width="1912" height="946" alt="Google" src="https://github.com/user-attachments/assets/a2c35dc2-ec1c-48df-90f3-2ff53708892a" />
<img width="1890" height="951" alt="Redirection" src="https://github.com/user-attachments/assets/fa47f0d9-a06b-4a55-bc6d-f60b96e56897" />
<img width="1899" height="950" alt="NoteBoxes" src="https://github.com/user-attachments/assets/a8442ff4-13c9-48aa-b761-a8342d1d39d5" />
<img width="1885" height="940" alt="Notes" src="https://github.com/user-attachments/assets/713d00bb-c4e9-4662-aeb5-5442426c81a0" />
<img width="1890" height="953" alt="New" src="https://github.com/user-attachments/assets/472218d0-f3a7-48c0-a5c7-19260ce846e2" />
<img width="1895" height="953" alt="View" src="https://github.com/user-attachments/assets/3e22bad5-9d42-4fc9-84b2-23cbf0e91eb3" />
<img width="1897" height="954" alt="Edit" src="https://github.com/user-attachments/assets/338884ae-3819-4a90-aaa3-3c56be6a50e0" />

* * * * *

🔮 Future Improvements
----------------------

-   Add **rich text editing** for notes

-   Add **tags and search** functionality

-   Add **collaborative editing**

-   Implement **error handling middleware**

* * * * *

📜 License
----------

This project is licensed under the MIT License.

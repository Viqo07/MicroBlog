# Micro Blog

This project is a simple Micro Blog application built with ASP.NET Core Razor Pages.

## Features

- Create blog posts
- View all blog posts
- View individual blog posts
- Edit blog posts
- Delete blog posts
- Store posts in a JSON file
- Use a shared layout
- Use a reusable `_PostCard` partial view
- Use static CSS files

## Pages

### Index

The Index page displays all blog posts using the `_PostCard` partial.

### Create

The Create page allows users to create a new blog post.

### Details

The Details page displays an individual blog post.

### Edit

The Edit page allows users to update an existing blog post.

### Delete

The Delete page allows users to delete an existing blog post.

## Data Persistence

Blog posts are stored in:

`data/posts.json`

The application loads existing posts from the JSON file when it starts and saves changes when posts are created, edited, or deleted.

## Screenshots

### Index Page

Insert your Index screenshot here.

### Create Page

Insert your Create screenshot here.

### Details Page

Insert your Details screenshot here.
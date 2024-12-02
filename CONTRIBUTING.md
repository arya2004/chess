
# Contributing to Chess Game

Thank you for your interest in contributing to the Chess Game project! Contributions are welcome and greatly appreciated. Whether it's reporting a bug, suggesting a feature, or submitting a pull request, your involvement helps improve the project.

## 📝 Table of Contents

- [How Can I Contribute?](#how-can-i-contribute)
  - [Report Bugs](#report-bugs)
  - [Suggest Features](#suggest-features)
  - [Submit Pull Requests](#submit-pull-requests)
- [Code Guidelines](#code-guidelines)
  - [Code Style](#code-style)
  - [Commit Messages](#commit-messages)
- [Development Workflow](#development-workflow)
- [Getting Help](#getting-help)

---

## How Can I Contribute?

### Report Bugs

If you find a bug:

1. **Search existing issues** to ensure the bug hasn't been reported.
2. Open a new issue and include:
   - A clear and concise title.
   - Steps to reproduce the bug.
   - Expected and actual behavior.
   - Screenshots or code snippets, if applicable.

### Suggest Features

Have a feature in mind?

1. Check existing issues to see if the feature has already been suggested.
2. Open a new issue with:
   - A clear and descriptive title.
   - Explanation of the feature and why it's needed.
   - Any potential implementation ideas.

### Submit Pull Requests

Ready to code? Follow these steps:

1. **Fork** the repository and clone it to your local machine.
2. Create a new branch for your changes:
   ```bash
   git checkout -b feature/your-feature-name
   ```
3. Make your changes and commit them:
   ```bash
   git add .
   git commit -m "Add: Description of your feature or fix"
   ```
4. Push your branch:
   ```bash
   git push origin feature/your-feature-name
   ```
5. Submit a pull request (PR) from your branch to the `main` branch of this repository.

   - Provide a clear description of the changes made.
   - Reference any related issues (e.g., "Closes #123").

---

## Code Guidelines

### Code Style

- **C#:**
  - Use **PascalCase** for public methods, properties, and classes.
  - Use **camelCase** for local variables and private fields.
  - Follow **Microsoft's C# coding conventions**: [C# Coding Guidelines](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions).

- **XAML:**
  - Organize attributes alphabetically for readability.
  - Use meaningful names for controls (e.g., `ChessBoardGrid`).

### Commit Messages

- Use a short, descriptive summary (max 72 characters).
- Use prefixes to indicate the type of change:
  - `Add:` for new features.
  - `Fix:` for bug fixes.
  - `Update:` for changes to existing functionality.
  - `Refactor:` for code improvements without changing functionality.
  - `Docs:` for documentation updates.

---

## Development Workflow

1. **Set up the environment:**
   - Install Visual Studio with the WPF development tools.
   - Clone the repository and restore NuGet packages.

2. **Test changes locally:**
   - Run the application to verify UI changes.
   - Use the Test Explorer to validate unit tests.

3. **Write tests:**
   - Add or update unit tests for any new or changed functionality.

4. **Submit a PR:**
   - Ensure the PR is against the `main` branch.
   - Include screenshots or videos for UI changes.

---

## Getting Help

If you encounter any issues while contributing, feel free to:

- Check the [issues](https://github.com/arya2004/chess/issues) for similar questions or discussions.
- Open a new issue with your question or problem.

Thank you for helping make Chess Game better! 💡


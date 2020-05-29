# Changelog
All notable changes to this project will be documented in this file.
This Visual Studio solution consists of two projects.  The Base is truly the most important project, but the Test project is what gets installed.
Therefore, the Visual Studio version numbers for Base are never changed (likely stuck at 1.0.0.0); the Visual Studio version number for Test will
correspond to numbers in this change log.


## [1.1.1] - 2020-05-29
### Changes
- Fix bug: The window must be the original size if the Escape key is used to exit from resizing and moving the red frame.

## [1.1.0] - 2020-05-29
### Changes
- Version format is now MAJOR.MINOR.PATCH which will correspond to Visual Studio version MAJOR.MINOR.zero.REVISION where the unneeded Build number will always be 0.
- Refactored code to use SystemInformation.VirtualScreen instead of method GetLogicalScreenBounds().
- Refactored code for window resizing actions.
- Fix bug: Do not allow resizing to width or height less than 10.


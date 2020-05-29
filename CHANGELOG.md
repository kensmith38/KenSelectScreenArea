# Changelog
All notable changes to this project will be documented in this file.

## [1.1.0] - 2020-05-29
### Changes
- Version format is now MAJOR.MINOR.PATCH which will correspond to Visual Studio version MAJOR.MINOR.zero.REVISION where the unneeded Build number will always be 0.
- Refactored code to use SystemInformation.VirtualScreen instead of method GetLogicalScreenBounds().
- Refactored code for window resizing actions.
- Fix bug: Do not allow resizing to width or height less than 10.


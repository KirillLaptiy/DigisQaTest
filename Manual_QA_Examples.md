**Test Case: Booking Flow (Hotel Platform)**
*   **ID:** TC-001
*   **Title:** Successful room booking with valid payment data
*   **Preconditions:** User is logged in, room is available for selected dates.
*   **Steps:**
    1. Select check-in and check-out dates
    2. Click "Book Now"
    3. Fill in guest details (Name, Email, Phone)
    4. Enter valid credit card details (using sandbox)
    5. Click "Confirm Payment"
*   **Expected Result:** Payment is processed, booking confirmation page is displayed, email with confirmation is sent to the user

**Bug Report (Example):**
*   **Summary:** Error 500 is returned when booking a room with special characters in the guest name
*   **Environment:** Windows 11, Chrome v120, Staging env
*   **Steps to Reproduce:**
    1. Go to booking page
    2. Fill guest name with `John Doe <script>`
    3. Click "Confirm Payment"
*   **Expected Result:** Validation error (400 Bad Request) indicating that special characters are not allowed
*   **Actual Result:** Server returns 500 Internal Server Error and the page crashes
*   **Severity:** Major
*   **Priority:** High
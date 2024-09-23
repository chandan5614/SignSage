export interface User {
  id: string;
  username: string;
  email: string;
  role: string; // e.g., 'admin', 'user', etc.
  createdAt: Date;
  updatedAt: Date;
}

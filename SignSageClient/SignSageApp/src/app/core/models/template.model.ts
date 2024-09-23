export interface Template {
  id: string;
  name: string;
  content: string;
  createdAt: Date;
  updatedAt: Date;
  ownerId: string; // User ID of the owner
}

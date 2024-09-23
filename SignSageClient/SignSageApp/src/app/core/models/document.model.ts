export interface Document {
  id: string;
  title: string;
  content: string;
  createdAt: Date;
  updatedAt: Date;
  ownerId: string; // User ID of the owner
  status: string; // e.g., 'draft', 'finalized', etc.
}

export interface Renewal {
  id: string;
  documentId: string; // ID of the associated document
  userId: string; // User ID requesting the renewal
  requestDate: Date;
  status: string; // e.g., 'pending', 'approved', 'denied'
}

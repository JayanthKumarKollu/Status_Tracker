export interface PageResponse<T> {
  TotalRecords: Number;
  PageSize: Number;
  PageNumber: Number;
  Data: T[];
}

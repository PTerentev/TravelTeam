import { Metadata } from './Metadata'

export class PagedListDto<T> {
    metadata: Metadata;
    items: T[]
}
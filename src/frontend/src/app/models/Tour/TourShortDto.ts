import { UserDto } from '../UserDto';

export class TourShortDto {
    id: number;
    date: Date;
    title: string;
    description: string;
    movementType: string;
    creatorUser: UserDto;
}